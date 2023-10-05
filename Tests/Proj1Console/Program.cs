using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
            var client = new HttpClient();

            // WebClient client = new WebClient();

            var csv_str = client.GetAsync(data_url).Result;

            Console.ReadLine();

        }
    }
}
