﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proj1Console
{
    internal class Program
    {
        private const string data_url = @"https://github.com/CSSEGISandData/COVID-19/blob/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = GetDataStream().Result;
            using var data_reader = new StreamReader(data_stream);

            while(!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line.Replace("Korea,", "Korea -");
            }
        }

        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string Country, string Province, int[] Counts)> GetData() {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));

            foreach(var row in lines)
            {
                var province = row[0].Trim();
                var country_name = row[1].Trim(' ', '"');
                var counts = row.Skip(4).Select(int.Parse).ToArray();
            
                yield return (province, country_name, counts);
            }

        }
        static void Main(string[] args)
        {
            var client = new HttpClient();

            // WebClient client = new WebClient();

          //  var response = client.GetAsync(data_url).Result;
           // var csv_str = response.Content.ReadAsStringAsync().Result;
            
           // foreach(var data_line in GetDataLines())
         //   {
          //      Console.WriteLine(data_line);
          //  }

            //var dates = GetDates();
            //Console.WriteLine(string.Join("\r\n", dates));

            var russia_data = GetData().First(v => v.Country.Equals("China", StringComparison.OrdinalIgnoreCase));
            Console.Write(string.Join("\r\n", GetDates().Zip(russia_data.Counts, (date, count) => $"{date:dd:MM} - {count}")));
            Console.ReadLine();

        }
    }
}
