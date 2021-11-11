using System;
using System.Collections;
using System.Collections.Generic;
using Npgsql;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IDataService
    {

        //title
        IList<Title> GetTitles();
        Title GetTitle(string tconst);
        IList<Title> GetPopularTitles();

        //actor
        IList<Actor> GetActors();
        Actor GetActor(string nconst);
        Actor CreateActor(string nconst, string primaryname);

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

        //TODO: Count words function? do we need this?


        IList<Title> BestMatchFunction(string input1, string input2, string input3);
        


  
        IList<Title> ExactMatchDynamicSearch(string[] input);

   
        IList<Title> FindSimilarSearch(string input);
        
  

        IList<BookmarkTitle> GetAllTitleBookmarksByUser(string uconst);

        IList<UserRating> GetAllUserRatings();

        
        IList<UserRating> GetUserRatingFromSpecificUser(string uconst, string tconst);

        

        IList<Title> GetPopularActorsRankedByTitles(string tconst);

        

        IList<Title> StringSearch(string searchparams, string userid);

        //TODO: Structured Name Search

        IList<Actor> StructuredNameSearch(string input);

        //TODO: Structured string search

        IList<Title> StructuredStringSearch(string titleinput, string plotinput, string characterinput,
            string personnameinput, string useridinput);

        //TODO: WordToWord 

        IList<Title> WordToWord(string[] input);

    }
}
