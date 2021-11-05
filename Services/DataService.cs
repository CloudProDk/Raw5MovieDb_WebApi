using Raw5MovieDb_WebApi.Model;
using System.Collections.Generic;
using System.Linq;


namespace Raw5MovieDb_WebApi.Services
{
    public class DataService : IDataService
    {
        private readonly List<Title> _titles = new List<Title>
        {
            new Title{ Tconst = "t00001", Primarytitle = "Interstellar", Originaltitle = "Interstellar", Startyear = "2014", Endyear = "2014", Isadult = false, Runtimeminutes = 169, Titletype = "movie" },
            new Title{ Tconst = "t00002", Primarytitle = "Alien", Originaltitle = "Alien", Startyear = "1979", Endyear = "1979", Isadult = false, Runtimeminutes = 117, Titletype = "movie" },
            new Title{ Tconst = "t00003", Primarytitle = "Squid Game", Originaltitle = "Squid Game", Startyear = "2021", Endyear = "2021", Isadult = false, Runtimeminutes = 60, Titletype = "tvMiniSeries" },
            new Title{ Tconst = "t00004", Primarytitle = "Breaking Bad", Originaltitle = "Breaking Bad", Startyear = "2008", Endyear = "2013", Isadult = false, Runtimeminutes = 49, Titletype = "tvSeries" },
            new Title{ Tconst = "t00005", Primarytitle = "Dune", Originaltitle = "Dune", Startyear = "2021", Endyear = "2021", Isadult = false, Runtimeminutes = 155, Titletype = "movie" },
        };

        private readonly List<Actor> _actors = new List<Actor>
        {
            new Actor{ Nconst = "n00001", Primaryname = "Brad Pitt", Birthyear = "1963", Deathyear = null, Knownfortitles = "", Primaryprofession = "actor,writer,producer", Namerating = 8.41 },
            new Actor{ Nconst = "n00002", Primaryname = "Matt Damon", Birthyear = "1970", Deathyear = null, Knownfortitles = "t00001", Primaryprofession = "actor,writer,producer", Namerating = 7.58 },
            new Actor{ Nconst = "n00003", Primaryname = "Sigourney Weaver", Birthyear = "1949", Deathyear = null, Knownfortitles = "t00002", Primaryprofession = "actor,writer", Namerating = 7.94 },
            new Actor{ Nconst = "n00004", Primaryname = "Timothée Chalamet", Birthyear = "1995", Deathyear = null, Knownfortitles = "t00005", Primaryprofession = "actor", Namerating = 7.50 },
        };

        private readonly List<User> _users = new List<User> {
            new User{ UserId = 1, FirstName = "John", LastName = "Doe", UserName = "MrJohnDoe", Password = "Windows>macOS", Token = "" },
            new User{ UserId = 2, FirstName = "Jane", LastName = "Doe", UserName = "MsJaneDoe", Password = "macOS>Windows", Token = "" },
            new User{ UserId = 3, FirstName = "Sebastian", LastName = "Linux", UserName = "MrLinux", Password = "Linux>*", Token = "" },
        };

        public DataService()
        {
            //AddTitleBookmark();
        }

        public bool AddTitleBookmark(Title title, User user)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTitleBookmark(Title title, User user)
        {
            throw new System.NotImplementedException();
        }

        public Actor GetActor(string nconst)
        {
            return _actors.FirstOrDefault(x => x.Nconst == nconst);
        }

        public IList<Actor> GetActors()
        {
            return _actors;
        }

        public IList<Title> GetPopularTitles()
        {
            return _titles.Skip(1).ToList();
        }

        public Title GetTitle(string tconst)
        {
            return _titles.FirstOrDefault(x => x.Tconst == tconst);
        }

        public IList<Title> GetTitles()
        {
            return _titles;
        }

        public User GetUser(int userId)
        {
            return _users.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
