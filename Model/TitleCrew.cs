using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitleCrew
    {
         [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("directors")]
        public string Directors { get; set; }

        [JsonProperty("writers")]
        public string Writers { get; set; }
    }
}