using System.Collections.Generic;

namespace Proj1.Models
{
    internal class CountryInfo : PlaceInfo { 
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
