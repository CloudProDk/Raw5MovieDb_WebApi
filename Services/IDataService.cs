using System;
using System.Collections.Generic;
using Npgsql;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IDataService
    {

        //title
        IList<Title> GetTitles(QueryString queryString);
        Title GetTitle(string tconst);
        IList<Title> FindSimilarSearch(string tconst);
        IList<Title> GetPopularTitles();
        int TitlesCount();
        IList<Title> StringSearch(string searchparams, string userid);
        IList<Title> WordToWord(string[] input);


        //actor
        IList<Actor> GetActors(QueryString queryString);
        Actor GetActor(string nconst);
        IList<Actor> StructuredNameSearch(string input);
        int ActorsCount();
        IList<Actor> find_coplayers(string actorname);

        //genre
        Genre GetGenre(int genreId);

        // Bookmarkactor


        IList<BookmarkActor> GetAllActorBookmarks();
        BookmarkActor GetActorBookmark(string nconst,string uconst);


        // User
        UserAccount GetUser(string userId);
        UserAccount RegisterUser(CreateUserAccountViewModel model);
        IList<UserAccount> GetAllUsers();
        bool DeleteUser(string uconst);

        bool UpdateUser(UserAccount model);

        /*
        bool AddTitleBookmark(Title title, UserAccount user);
        bool DeleteTitleBookmark(Title title, UserAccount user);

        bool AddActorBookmark(Actor actor, UserAccount user);
        bool DeleteActorBookmark(Actor actor, UserAccount user);
        */

    }
}
