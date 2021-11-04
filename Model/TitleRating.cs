using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitleRating
    {
        [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("averagerating")]
        public long Averagerating { get; set; }

        [JsonProperty("numvotes")]
        public long Numvotes { get; set; }
    }
}