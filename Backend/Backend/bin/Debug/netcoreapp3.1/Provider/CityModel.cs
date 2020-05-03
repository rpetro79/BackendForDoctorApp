using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Provider
{
    public class CityModel
    {
        [JsonProperty("city_name")]
        public string city { get; set; }
    }
}
