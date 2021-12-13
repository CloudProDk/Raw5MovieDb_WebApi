define(['viewmodel'], function (vm)  {
    
    let getBookmarks = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch("/api/Bookmark/TitleBookmark/1", param)
            .then(response => response.json())
            .then(json => callback(json));

    };


    let deleteTitleBookmark = (TitleBookmark, uconst, tconst ) => {
        let param = {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch(`api/Bookmark/TitleBookmark?uconst=${uconst}&tconst=${tconst}`, param)
            .then(response => console.log(response.status))
    };


    let getActorBookmarks = (callback) => {
        let param = { 
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch("/api/Bookmark/ActorBookmark/1", param)
            .then(response => response.json())
            .then(json => callback(json));

    };

    let deleteActorBookmark = Actorbookmark => {
        fetch(ActorBookmark.nconst, { method: "DELETE" })
            .then(response => console.log(response.status))
    };


    return {
        getBookmarks,
        deleteTitleBookmark,
        getActorBookmarks,
        deleteActorBookmark
        
    }
});
