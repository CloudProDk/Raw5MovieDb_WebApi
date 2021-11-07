using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raw5MovieDb_WebApi.Model
{
    public class UserAccount
    {
        public int Uconst { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public List<UserRating> Ratings { get; set; };
        public List<UserSearchHistory> SearchHistory { get; set; };



    }
}