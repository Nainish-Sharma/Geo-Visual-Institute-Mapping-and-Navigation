using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace map.Models
{
    public class InstituteLocation
    {
        public int InstID { get; set; }

        public int AccCount { get; set; }
        public string InstName { get; set; }
        public string InstAddress { get; set; }
        public string CityID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}