using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Provider
{
    public class StateModel
    {
        [JsonProperty("state_name")]
        public string state { get; set; }
    }
}
