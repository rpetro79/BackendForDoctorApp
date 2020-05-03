using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Provider
{
    public class AuthenticationModel
    {
        [JsonProperty("auth_token")]
        public string authenticationString { get; set; }
    }
}
