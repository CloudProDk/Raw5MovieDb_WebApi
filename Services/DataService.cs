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


        public IList<BookmarkTitle> GetAllTitleBookmarks(string uconst)
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkTitles.Where(b => b.Uconst == uconst).ToList();
        }

        public BookmarkTitle GetBookmarkTitle(string uconst, string tconst)
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkTitles.Find(uconst, tconst);
        }

        public BookmarkTitle AddTitleBookmark(string tconst, string uconst)
        {
            var ctx = new MovieDbContext();
            var bm = new BookmarkTitle
            {
                Tconst = tconst,
                Uconst = uconst
            };
            ctx.Add(bm);
            ctx.SaveChanges();
            return bm;
        }

        public bool DeleteTitleBookmark(string tconst, string uconst)
        {
            var ctx = new MovieDbContext();
            var bm = ctx.bookmarkTitles.Find(tconst, uconst);

            if (bm != null)
            {
                ctx.bookmarkTitles.Remove(bm);
                return ctx.SaveChanges() > 0;
            }
            else return false;
        }


        /*
         *
         * BOOKMARK ACTOR CRUD
         * SHOULD BE DONE
         */

        public IList<BookmarkActor> GetAllActorBookmarks(string uconst)
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkActors.Where(b => b.Uconst == uconst).ToList();
        }

        public BookmarkActor GetActorBookmark(string uconst, string nconst)
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkActors.Find(uconst, nconst);
        }

        public BookmarkActor AddActorBookmark(string nconst, string uconst)
        {
            var ctx = new MovieDbContext();
            var bm = new BookmarkActor
            {
                Nconst = nconst,
                Uconst = uconst
            };
            ctx.Add(bm);
            ctx.SaveChanges();
            return bm;
        }

        public bool DeleteActorBookmark(string uconst, string nconst)
        {
            var ctx = new MovieDbContext();
            var bm = ctx.bookmarkActors.Find(nconst, uconst);

            if (bm != null)
            {
                ctx.bookmarkActors.Remove(bm);
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
            return ctx.titles.Include(x => x.TitleRating).Skip(queryString.Page * queryString.PageSize).Take(queryString.PageSize).ToList();
        }
        //linq
        public Title GetTitle(string tconst)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.Include(title => title.Genres).ThenInclude(titlegenre => titlegenre.Genre).Include(x => x.TitleRating).FirstOrDefault(x => x.Tconst == tconst);
        }
        //TODO: not implementet


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
        public IList<BookmarkTitle> GetAllTitleBookmarksByUser(string uconst)
        {
            var ctx = new MovieDbContext();
            return ctx.bookmarkTitles.FromSqlInterpolated($"SELECT * FROM get_all_bookmarks_from_user({uconst})").ToList();
            //return ctx.bookmarkTitles
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

        public IList<Genre> GetGenres(QueryString queryString)
        {
            var ctx = new MovieDbContext();
            return ctx.genres.Skip(queryString.Page * queryString.PageSize).Take(queryString.PageSize).ToList();
        }

        public Genre GetGenre(int genreId)
        {
            var ctx = new MovieDbContext();
            return ctx.genres.FirstOrDefault(x => x.Id == genreId);
        }

        public int GenresCount()
        {
            var ctx = new MovieDbContext();
            return ctx.genres.Count();
        }

        public IList<Title> GetTitlesByGenre(int genreId, QueryString queryString)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FromSqlInterpolated($"SELECT * FROM get_titles_by_genre({genreId}, {queryString.Page}, {queryString.PageSize})").ToList();
        }

        public int TitlesByGenreCount(int genreId)
        {
            var ctx = new MovieDbContext();
            return ctx.titles.FromSqlInterpolated($"SELECT tconst FROM get_titles_by_genre({genreId}, 0, 99999999)").Count();
        }

        //browse titles by genre
        //latest titles




        //view popular titles
        //f�r alle sammen, s� skal nok limites senere henne
        public IList<Title> GetPopularTitles()
        {
            var ctx = new MovieDbContext();
            return ctx.titles.Include(x => x.TitleRating).OrderByDescending(x => x.TitleRating.Averagerating * x.TitleRating.Numvotes).Take(25).ToList();
        }


        //view search history
        public IList<UserSearchHistory> GetUserSearchHistory(string uconst)
        {
            var ctx = new MovieDbContext();
            return ctx.userSearchHistories.Where(x => x.Uconst == uconst).ToList();
        }


        //RATE TITLE
        //TODO: needs a check if the rating allready exists, because otherwise, one can keep rating the same movie.
        public UserRating CreateTitleRating(long rating, string tconst, string uconst)
        {
            var ctx = new MovieDbContext();
            var newrating = new UserRating { Rating = rating, Tconst = tconst, Uconst = uconst };
            ctx.Add(newrating);
            ctx.SaveChanges();
            return newrating;

        }



        //Update Rating Title


        public bool UpdateTitleRating(long rating, string tconst, string uconst)
        {
            var ctx = new MovieDbContext();
            var rat = ctx.userRatings.Find(rating,tconst, uconst);

            if (rat != null)
            {
                rat.Rating = rating;
                rat.Tconst = tconst;
                rat.Uconst = uconst;
                return ctx.SaveChanges() > 0;
            }
            else return false;
        }


    }
}
