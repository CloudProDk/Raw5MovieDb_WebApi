using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class UserAccount
    {
        [JsonProperty("uconst")]
        public int Uconst { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("email")] 
        public string Email { get; set; }

        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        public List<UserRating> Ratings { get; set; }
        public List<UserSearchHistory> SearchHistory { get; set; }



    }
}