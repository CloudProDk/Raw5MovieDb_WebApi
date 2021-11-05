using System.Collections.Generic;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IDataService
    {
        IList<Title> GetTitles();
        Title GetTitle(string tconst);
        IList<Title> GetPopularTitles();
        IList<Actor> GetActors();
        Actor GetActor(string nconst);
        User GetUser(int userId);

        bool AddTitleBookmark(Title title, User user);
        bool DeleteTitleBookmark(Title title, User user);
    }
}
