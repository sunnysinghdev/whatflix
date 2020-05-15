using System.Collections.Generic;
using Newtonsoft.Json;

namespace Covid19.Domain
{
    public class Location
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        public int zipcode { get; set; }
        public int zone { get; set; }
        //public int zoneCode { get; set; } // 0 red, 1 orange, 2 red
        public int cases { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public List<string> streets { get; set; }
    }
}