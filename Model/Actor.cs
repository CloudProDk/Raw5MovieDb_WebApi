using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Raw5MovieDb_WebApi.Model
{
    public class Actor
    {
        [JsonProperty("nconst")]
        public string Nconst { get; set; }

        [JsonProperty("primaryname")]
        public string Primaryname { get; set; }

        [JsonProperty("birthyear")]
        public string Birthyear { get; set; }

        [JsonProperty("deathyear")]
        public string Deathyear { get; set; }

        [JsonProperty("primaryprofession")]
        public string Primaryprofession { get; set; }

        [JsonProperty("knownfortitles")]
        public string Knownfortitles { get; set; }

        [JsonProperty("namerating")]
        public double Namerating { get; set; }
    }
}