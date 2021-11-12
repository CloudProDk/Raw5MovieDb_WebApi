using System;
using Raw5MovieDb_WebApi.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Services
{
    public class DataService : IDataService
    {
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
            return ctx.userAccounts.FirstOrDefault(x => x.Uconst == uconst);
        }

        public IList<UserAccount> GetAllUsers()
        {
            var ctx = new MovieDbContext();
            //return ctx.userAccountss.FromSqlInterpolated($"SELECT * FROM get_all_users()").ToList();
            return ctx.userAccounts.ToList();
        }

        public UserAccount RegisterUser(CreateUserAccountViewModel user)
        {
            var ctx = new MovieDbContext();
            
            var newUser = new UserAccount
            {
                Uconst = (Int32.Parse(ctx.userAccounts.Max(x => x.Uconst)) + 1).ToString(),
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Birthdate = user.Birthdate
            };


            ctx.Add(newUser);
            ctx.SaveChanges();
            return newUser;
        }



        public bool DeleteUser(string uconst)
        {
            var ctx = new MovieDbContext();
            var user = ctx.userAccounts.Find(uconst);

            if (user != null)
            {
                ctx.userAccounts.Remove(user);
                return ctx.SaveChanges() > 0;
            }
            else return false;
        }



        public bool UpdateUser(UserAccount model)
        {
            var ctx = new MovieDbContext();
            var user = ctx.userAccounts.Find(model.Uconst);

            if (user != null)
            {
                user.Uconst = user.Uconst;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Birthdate = model.Birthdate;
                user.Password = model.Password;

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
            return ctx.titles.Include(title => title.Genres).ThenInclude(titlegenre => titlegenre.Genre).FirstOrDefault(x => x.Tconst == tconst);
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

        public Genre GetGenre(int genreId)
        {
            var ctx = new MovieDbContext();
            return ctx.genres.FirstOrDefault(x => x.Id == genreId);
        }
    }
}
