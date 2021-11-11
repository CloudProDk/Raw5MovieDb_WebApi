using System;
using System.Collections.Generic;
using Npgsql;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IDataService
    {

        //title
        IList<Title> GetTitles(QueryString queryString);
        Title GetTitle(string tconst);
        IList<Title> GetPopularTitles();
        int TitlesCount();

        //actor
        IList<Actor> GetActors(QueryString queryString);
        Actor GetActor(string nconst);
        Actor CreateActor(string nconst, string primaryname);
        int ActorsCount();

        bool DeleteActor(string nconst);

        bool UpdateActor(string nconst, string primaryname);

        // Bookmarkactor
        IList<BookmarkActor> GetAllActorBookmarks();
        BookmarkActor GetActorBookmark(string nconst,string uconst);


        // User


        UserAccount GetUser(string userId);


        /*
        bool AddTitleBookmark(Title title, UserAccount user);
        bool DeleteTitleBookmark(Title title, UserAccount user);

        bool AddActorBookmark(Actor actor, UserAccount user);
        bool DeleteActorBookmark(Actor actor, UserAccount user);
        */

    }
}
