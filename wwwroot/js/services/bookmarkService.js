define([], () => {

    let getBookmarks = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4OTk1ODAxLCJleHAiOjE2Mzg5OTc2MDEsImlhdCI6MTYzODk5NTgwMX0.gjPhbupsXrO0ak9SiBCOSDxWAqalLz1kjNfi_r_WyDk'
            }
        }
        fetch("/api/Bookmark/TitleBookmark/1", param)
            .then(response => response.json())
            .then(json => callback(json));

    };


    let deleteTitleBookmark = TitleBookmark => {
        fetch("/api/Bookmark/TitleBookmark", { method: "DELETE" })
            .then(response => console.log(response.status))
    };


    let getActorBookmarks = (callback) => {
        let param = { 
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4OTk1ODAxLCJleHAiOjE2Mzg5OTc2MDEsImlhdCI6MTYzODk5NTgwMX0.gjPhbupsXrO0ak9SiBCOSDxWAqalLz1kjNfi_r_WyDk'
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