using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class UserSearchHistory
    {
        [JsonProperty("search_id")]
        public long SearchId { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("uconst")]
        public string Uconst { get; set; }
    }
}