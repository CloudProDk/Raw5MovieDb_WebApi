using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitleRating
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("tconst")]
        public string TitleRatingTconst { get; set; }

        [JsonProperty("averagerating")]
        public long Averagerating { get; set; }

        [JsonProperty("numvotes")]
        public long Numvotes { get; set; }

        public Title Title { get; set; }
    }
}