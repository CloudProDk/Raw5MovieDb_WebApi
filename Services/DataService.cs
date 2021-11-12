using System;
using Raw5MovieDb_WebApi.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Raw5MovieDb_WebApi.Services
{
    public class DataService : IDataService
    {
        private readonly List<Title> _titles = new List<Title>
        {
            new Title
            {
                Tconst = "t00001", Primarytitle = "Interstellar", Originaltitle = "Interstellar", Startyear = "2014",
                Endyear = "2014", Isadult = false, Runtimeminutes = 169, Titletype = "movie"
            },
            new Title
            {
                Tconst = "t00002", Primarytitle = "Alien", Originaltitle = "Alien", Startyear = "1979",
                Endyear = "1979", Isadult = false, Runtimeminutes = 117, Titletype = "movie"
            },
            new Title
            {
                Tconst = "t00003", Primarytitle = "Squid Game", Originaltitle = "Squid Game", Startyear = "2021",
                Endyear = "2021", Isadult = false, Runtimeminutes = 60, Titletype = "tvMiniSeries"
            },
            new Title
            {
                Tconst = "t00004", Primarytitle = "Breaking Bad", Originaltitle = "Breaking Bad", Startyear = "2008",
                Endyear = "2013", Isadult = false, Runtimeminutes = 49, Titletype = "tvSeries"
            },
            new Title
            {
                Tconst = "t00005", Primarytitle = "Dune", Originaltitle = "Dune", Startyear = "2021", Endyear = "2021",
                Isadult = false, Runtimeminutes = 155, Titletype = "movie"
            },
        };

        private readonly List<Actor> _actors = new List<Actor>
        {
            //new Actor
            //{
            //    Nconst = "n00001", Primaryname = "Brad Pitt", Birthyear = "1963", Deathyear = null, Knownfortitles = "",
            //    Primaryprofession = "actor,writer,producer", Namerating = 8.41
            //},
            //new Actor
            //{
            //    Nconst = "n00002", Primaryname = "Matt Damon", Birthyear = "1970", Deathyear = null,
            //    Knownfortitles = "t00001", Primaryprofession = "actor,writer,producer", Namerating = 7.58
            //},
            //new Actor
            //{
            //    Nconst = "n00003", Primaryname = "Sigourney Weaver", Birthyear = "1949", Deathyear = null,
            //    Knownfortitles = "t00002", Primaryprofession = "actor,writer", Namerating = 7.94
            //},
            //new Actor
            //{
            //    Nconst = "n00004", Primaryname = "Timothée Chalamet", Birthyear = "1995", Deathyear = null,
            //    Knownfortitles = "t00005", Primaryprofession = "actor", Namerating = 7.50
            //},
        };

        /* private readonly List<User> _users = new List<User> {
             new User{ UserId = 1, FirstName = "John", LastName = "Doe", UserName = "MrJohnDoe", Password = "Windows>macOS", Token = "" },
             new User{ UserId = 2, FirstName = "Jane", LastName = "Doe", UserName = "MsJaneDoe", Password = "macOS>Windows", Token = "" },
             new User{ UserId = 3, FirstName = "Sebastian", LastName = "Linux", UserName = "MrLinux", Password = "Linux>*", Token = "" },
         };*/





        /*
         *
         * BOOKMARK TITLE CRUD
         * SHOULD BE DONE
         */

        public IList<BookmarkTitle> GetAllBookmarkTitles()
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkTitles.ToList();
        }

        public BookmarkTitle GetBookmarkTitle(string uconst, string tconst)
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkTitles.Find(uconst, tconst);
        }

        //TODO test this, not sure if the right output comes
        public BookmarkTitle AddTitleBookmark(string tconst, string uconst)
        {
            var ctx = new MovieDbContext();
            var act = new BookmarkTitle
            {
                Tconst = ctx.bookmarkTitles.Max(x => x.Tconst) + 1,
                Uconst = uconst
            };
            ctx.Add(act);
            ctx.SaveChanges();
            return act;
        }

        public bool DeleteTitleBookmark(string tconst, string uconst)
        {
            var ctx = new MovieDbContext();
            var act = ctx.bookmarkTitles.Find(tconst, uconst);

            if (act != null)
            {
                ctx.bookmarkTitles.Remove(act);
                return ctx.SaveChanges() > 0;
            }
            else return false;
        }


        /*
         *
         * BOOKMARK ACTOR CRUD
         * SHOULD BE DONE
         */

        public IList<BookmarkActor> GetAllActorBookmarks()
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkActors.ToList();
        }

        public BookmarkActor GetActorBookmark(string uconst, string nconst)
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkActors.Find(uconst, nconst);
        }

        //TODO test this, not sure if works
        public BookmarkActor AddActorBookmark(string uconst, string nconst)
        {
            var ctx = new MovieDbContext();
            var act = new BookmarkActor
            {
                Nconst = ctx.bookmarkActors.Max(x => x.Nconst) + 1,
                Uconst = uconst
            };
            ctx.Add(act);
            ctx.SaveChanges();
            return act;
        }

        public bool DeleteActorBookmark(string uconst, string nconst)
        {
            var ctx = new MovieDbContext();
            var act = ctx.bookmarkActors.Find(nconst, uconst);

            if (act != null)
            {
                ctx.bookmarkActors.Remove(act);
                return ctx.SaveChanges() > 0;
            }
            else return false;
        }





        //User methods


        public UserAccount GetUser(string uconst)
        {
            var ctx = new MovieDbContext();
            return ctx.users.FirstOrDefault(x => x.Uconst == uconst);
        }

        public IList<UserAccount> GetAllUsersFunctionFromDatabase()
        {
            var ctx = new MovieDbContext();
            return ctx.users.FromSqlInterpolated($"SELECT * FROM get_all_users()").ToList();
        }

        public UserAccount AddUser(string uconst, string username, string Email, DateTime birthdate, string password)
        {
            var ctx = new MovieDbContext();
            var user = new UserAccount
            {
                Uconst = ctx.bookmarkTitles.Max(x => x.Uconst) + 1,
                UserName = username,
                Email = Email,
                Birthdate = birthdate,
                Password = password

            };
            ctx.Add(user);
            ctx.SaveChanges();
            return user;
        }



        public bool DeleteUser(string uconst)
        {
            var ctx = new MovieDbContext();
            var user = ctx.users.Find(uconst);

            if (user != null)
            {
                ctx.users.Remove(user);
                return ctx.SaveChanges() > 0;
            }
            else return false;
        }



        public bool UpdateUser(string uconst, string username, string email, DateTime birthdate, string password)
        {
            var ctx = new MovieDbContext();
            var user = ctx.users.Find(uconst);

            if (user != null)
            {
                user.Uconst = uconst;
                user.UserName = username;
                user.Email = email;
                user.Birthdate = birthdate;
                user.Password = password;

                return ctx.SaveChanges() > 0;
            }
            else return false;
        }


        /*
         * ACTOR METHODS
         * SHOULD BE DONE
         */


        public IList<Actor> GetActors(QueryString queryString)
        {
            var ctx = new MovieDbContext();
            return ctx.actors.Skip(queryString.Page * queryString.PageSize).Take(queryString.PageSize).ToList();
        }

        public Actor GetActor(string nconst)
        {
            var ctx = new MovieDbContext();
            return ctx.actors.FirstOrDefault(x => x.Nconst == nconst);
        }

        public int ActorsCount()
        {
            var ctx = new MovieDbContext();
            return ctx.actors.Count();
        }



        public Actor CreateActor(string nconst, string primaryname)
        {
            var ctx = new MovieDbContext();
            var act = new Actor
            {
                Nconst = ctx.actors.Max(x => x.Nconst) + 1,
                Primaryname = primaryname,
                //Birthyear = birthyear,
                //Deathyear = deathyear,
                //Primaryprofession = primaryprofession,
                //Knownfortitles = knownfortitles,
                //Namerating = namerating
            };
            ctx.Add(act);
            ctx.SaveChanges();
            return act;
        }

        public bool DeleteActor(string nconst)
        {
            var ctx = new MovieDbContext();
            var act = ctx.actors.Find(nconst);

            if (act != null)
            {
                ctx.actors.Remove(act);
                return ctx.SaveChanges() > 0;
            }
            else return false;
        }

        public bool UpdateActor(string nconst, string primaryname)
        {
            var ctx = new MovieDbContext();
            var act = ctx.actors.Find(nconst);

            if (act != null)
            {
                act.Nconst = nconst;
                act.Primaryname = primaryname;
                //act.Birthyear = birthyear;
                //act.Deathyear = deathyear;
                //act.Primaryprofession = primaryprofession;
                //act.Knownfortitles = knownfortitles;
                //act.Namerating = namerating;
                return ctx.SaveChanges() > 0;
            }
            else return false;
        }





        //title Methods
        //linq

        public IList<Title> GetTitles(QueryString queryString)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.Skip(queryString.Page * queryString.PageSize).Take(queryString.PageSize).ToList();
        }
        //linq
        public Title GetTitle(string tconst)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FirstOrDefault(x => x.Tconst == tconst);
        }
        //TODO: not implementet
        public IList<Title> GetPopularTitles()
        {
            throw new NotImplementedException();
        }

        public int TitlesCount()
        {
            var ctx = new MovieDbContext();
            return ctx.titles.Count();
        }

        //Works
        public IList<Actor> find_coplayers(string actorname)
        {
            var ctx = new MovieDbContext();
            return ctx.actors.FromSqlInterpolated($"SELECT * FROM find_coplayers({actorname}) NATURAL JOIN name_basics").ToList();
        }

        // works
        public IList<Title> BestMatchFunction(string input1, string input2, string input3)
        {
            var ctx = new MovieDbContext();
            return ctx.titles
                .FromSqlInterpolated(
                    $"SELECT * FROM bestmatch({input1},{input2},{input3}) NATURAL JOIN title_basics").ToList();
        }

        //WORKS - needs the position in the array specified
        public IList<Title> ExactMatchDynamicSearch(string[] words)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FromSqlInterpolated($"SELECT * FROM exact_match_dynamic({words[0]}) NATURAL JOIN title_basics").ToList();
        }
        // Works!!
        // Needs specific tconst as input
        public IList<Title> FindSimilarSearch(string tconst)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FromSqlInterpolated($"SELECT * FROM find_similar({tconst}) NATURAL JOIN title_basics LIMIT 100").ToList();
        }
        //TODO; not done, not a bookmark title, it is both a bookmark title and bookmark actor
        public IList<BookmarkTitle> GetAllBookmarksByUser(string userid)
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkTitles.FromSqlInterpolated($"SELECT * FROM get_all_bookmarks_from_user({userid})     ").ToList();
        }



        //TODO does not work, it says that it needs useraccount.uconst for some reason
        public IList<UserRating> GetAllUserRatings()
        {
            var ctx = new MovieDbContext();
            return ctx.userRatings.ToList();
        }

        //TODO for some reason, we can seem to get this to work. Neither in db or here.  LINQ VERSION BELOW
        /*public IList<UserRating> GetUserRatingFromSpecificUser(string uconst, string tconst)
        {
            var ctx = new MovieDbContext();
            return ctx.userRatings.FromSqlRaw($"SELECT * FROM get_rating({uconst},{tconst})").ToList();
        }*/
        public IList<UserRating> GetUserRatingFromSpecificUser(string uconst, string tconst)
        {
            var ctx = new MovieDbContext();
            return ctx.userRatings.Where(x => x.Uconst == uconst && x.Tconst == tconst).ToList();
        }



        //WORKS
        public IList<Title> GetPopularActorsRankedByTitles(string tconst)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FromSqlInterpolated($"SELECT * FROM popular_actors_ranked_by_movie({tconst}) NATURAL JOIN title_basics NATURAL JOIN name_basics NATURAL JOIN title_principals").ToList();
        }


        //TODO: not sure how procedures are supposed to work here
        public IList<UserRating> RateProcedure(string uid, string tid, int rating)
        {
            var ctx = new MovieDbContext();
            return ctx.userRatings.FromSqlInterpolated($"SELECT * FROM rate({uid},{tid},{rating})").ToList();
        }

        //WORKS
        public IList<Title> StringSearch(string searchparams, string userid)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FromSqlInterpolated($"SELECT * FROM string_search({searchparams},{userid}) NATURAL JOIN title_basics NATURAL JOIN omdb_data").ToList();
        }
        //works
        public IList<Actor> StructuredNameSearch(string input)
        {
            var ctx = new MovieDbContext();
            return ctx.actors.FromSqlInterpolated($"SELECT * FROM structured_name_search({input}) NATURAL JOIN name_basics").ToList();
        }
        //works
        public IList<Title> StructuredStringSearch(string titleinput, string plotinput, string characterinput, string personnameinput, string useridinput)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FromSqlInterpolated($"SELECT * FROM structured_string_search({titleinput}, {plotinput}, {characterinput} , {personnameinput}, {useridinput}) NATURAL JOIN omdb_data natural JOIN title_principals NATURAL join name_basics NATURAL JOIN title_basics").ToList();
        }
        //works
            public IList<Title> WordToWord(string[] input)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FromSqlInterpolated($"SELECT * FROM word_to_word({input[0]}) NATURAL JOIN title_basics").ToList();

        }
    }
}
