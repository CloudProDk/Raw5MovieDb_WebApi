using System.Collections.Generic;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IDataService
    {
        // Titles
        IList<Title> GetTitles();
        Title GetTitle(string tconst);
        IList<Title> GetPopularTitles();
        IList<Title> GetLatestTitles();
        IList<Title> GetTitlesByGenre(int genreId);
        IList<Title> FindTitle(string searchQuery);

        // Actors
        IList<Actor> GetActors();
        Actor GetActor(string nconst);

        // Users
        User GetUser(string uconst);

        // Bookmarks
        BookmarkTitle AddTitleBookmark(Title title, User user);
        bool DeleteTitleBookmark(Title title, User user);
        
        // Ratings
        TitleRating AddTitleRating(Title title, User user, int rating);
        TitleRating UpdateTitleRating(Title title, User user, int rating);
        bool DeleteTitleRating(Title title, User user);
    }
}
