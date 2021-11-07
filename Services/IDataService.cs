using System.Collections.Generic;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IDataService
    {
        IList<Title> GetTitles();
        Title GetTitle(string tconst);
        IList<Title> GetPopularTitles();

        //actor CRUD METHODS
        IList<Actor> GetActors();
        Actor GetActor(string nconst);
        Actor CreateActor(string nconst, string primaryname, string birthyear, string deathyear, string primaryprofession, string knownfortitles, double namerating);
        bool DeleteActor(string nconst)
        bool UpdateActor(string nconst, string primaryname, string birthyear, string deathyear, string primaryprofession, string knownfortitles, double namerating)

        // Bookmark CRUD METHODS
        IList<BookmarkActor> GetActorBookmarks();

        




        User GetUser(int userId);

        bool AddTitleBookmark(Title title, User user); 
        bool DeleteTitleBookmark(Title title, User user);

        bool AddActorBookmark(Actor actor, User user);
        bool DeleteActorBookmark(Actor actor, User user);
    }
}
