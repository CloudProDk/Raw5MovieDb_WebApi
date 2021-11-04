using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
public partial class OmdbData
    {
        [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("poster")]
        public Uri Poster { get; set; }

        [JsonProperty("awards")]
        public string Awards { get; set; }

        [JsonProperty("plot")]
        public string Plot { get; set; }
    }
}