using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Provider
{
    public class CountryModel
    {
        [JsonProperty("country_name")]
        public string countryName { get; set; }
        [JsonProperty("country_short_name")]
        public string countryShortName { get; set; }
        [JsonProperty("country_phone_code")]
        public string countryPhoneCode { get; set; }
    }
}
