using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitleEpisode
    {
        [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("parenttconst")]
        public string Parenttconst { get; set; }

        [JsonProperty("seasonnumber")]
        public long Seasonnumber { get; set; }

        [JsonProperty("episodenumber")]
        public long Episodenumber { get; set; }
    }
}