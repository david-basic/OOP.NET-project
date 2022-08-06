using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StartingEleven
    {
        [JsonProperty("name")]
        public string FullName { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        //public override string ToString()
        //{
        //    return $"{FullName}, captain:{Captain}, Num:{ShirtNumber}, {Position}";
        //}
    }
}
