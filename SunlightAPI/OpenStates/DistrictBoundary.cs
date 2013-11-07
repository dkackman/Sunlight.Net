using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.OpenStates
{
    public class Region
    {
        public double lon_delta { get; set; }
        public double center_lon { get; set; }
        public double lat_delta { get; set; }
        public double center_lat { get; set; }
    }

    public class DistrictBoundary
    {
        public string name { get; set; }
        public Region region { get; set; }
        public string chamber { get; set; }
        public List<List<List<List<double>>>> shape { get; set; }
        public string abbr { get; set; }
        public string boundary_id { get; set; }
        public int num_seats { get; set; }
        public string id { get; set; }
        public List<List<double>> bbox { get; set; }
    }
}
