using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proj1.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }
    internal class ProvinceInfo : PlaceInfo { }
}
