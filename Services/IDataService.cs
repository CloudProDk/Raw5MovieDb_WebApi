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


        //TODO: Best Match Function(string 1, string 2, string 3 inputs)
        IList<Title> BestMatchFunction(string input1, string input2, string input3);
        
        //TODO: Exact Match Dynamic(Arraylist input)
        IList<Title> ExactMatchDynamicSearch(string[] input);

        //TODO: Find Similar function(bpchar input)
        IList<Title> FindSimilarSearch(string input);
        
        //TODO: GetAllBookmarksFromUserFunction(Uconst input)

        
        //TODO: Get all ratings, is this based on user or just all ratings? or both?
        //TODO: Get rating(uconst, tconst inputs), probably the one rating for a specific movie
        //TODO: Popular actors by movie (string movie_input)
        //TODO: Rate procedure?
        //TODO: String_Search(String input, userid input)
        //TODO: Structured search
        //TODO: Structured Name Search
        //TODO: Structured string search
        //TODO: WordToWord 

    }
}
