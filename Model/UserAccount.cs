using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class UserAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("uconst")]
        public string Uconst { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("email")] 
        public string Email { get; set; }

        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        //[JsonProperty("token")]
        //public string? Token { get; set; } = "";

        public List<UserRating> Ratings { get; set; }
        public List<UserSearchHistory> SearchHistory { get; set; }



    }
}