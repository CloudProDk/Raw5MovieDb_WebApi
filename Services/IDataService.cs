using System;
using System.Collections.Generic;
using Npgsql;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IDataService
    {

        /* ------------------------- Title ------------------------- */
        IList<Title> GetTitles(QueryString queryString);
        Title GetTitle(string tconst);
        IList<Title> FindSimilarSearch(string tconst);
        int TitlesCount();
        IList<Title> StringSearch(string searchparams, string userid);
        IList<Title> WordToWord(string[] input);
        IList<TitleRating> GetPopularTitles();


        /* ------------------------- Actor ------------------------- */
        IList<Actor> GetActors(QueryString queryString);
        Actor GetActor(string nconst);
        IList<Actor> StructuredNameSearch(string input);
        int ActorsCount();
        IList<Actor> find_coplayers(string actorname);

        IList<TitleRating> GetPopularTitles();

        //genre
        IList<Genre> GetGenres(QueryString queryString);
        int GenresCount();
        Genre GetGenre(int genreId);
        IList<Title> GetTitlesByGenre(int genreId, QueryString queryString);
        int TitlesByGenreCount(int genreId);

        // Bookmarkactor

         /* ------------------------- Bookmark Actor ------------------------- */

        IList<BookmarkActor> GetAllActorBookmarks(string uconst);
        BookmarkActor GetActorBookmark(string nconst,string uconst);
        BookmarkActor AddActorBookmark(string nconst, string uconst);
        bool DeleteActorBookmark(string uconst, string nconst);

        /* ------------------------- Bookmark Title ------------------------- */

        // BookmarkTitle GetBookmarkTitle(string tconst, string uconst);
        IList<BookmarkTitle> GetAllTitleBookmarks(string uconst);
        BookmarkTitle AddTitleBookmark(string tconst, string uconst);
        bool DeleteTitleBookmark(string tconst, string uconst);

        /* ------------------------- User ------------------------- */

        UserAccount GetUser(string userId);
        UserAccount RegisterUser(CreateUserAccountViewModel model);
        IList<UserAccount> GetAllUsers();
        bool DeleteUser(string uconst);
        bool UpdateUser(UserAccount model);

        /* ------------------------- Search History ------------------------- */
        
        IList<UserSearchHistory> GetUserSearchHistory(string uconst);
        UserSearchHistory AddUserSearchHistory(UserSearchHistory model);

    }
}
