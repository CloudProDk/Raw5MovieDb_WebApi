define([], () => {

    let getBookmarks = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",

                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM5MDAxNzUxLCJleHAiOjE2MzkwMDM1NTEsImlhdCI6MTYzOTAwMTc1MX0.mCpuQb_Etpcz185Itx86h2JMvBJgnFefWWHCZaMW91g'

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
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM5MDAxNzUxLCJleHAiOjE2MzkwMDM1NTEsImlhdCI6MTYzOTAwMTc1MX0.mCpuQb_Etpcz185Itx86h2JMvBJgnFefWWHCZaMW91g'
            }
        }
        fetch(`api/Bookmark/TitleBookmark?uconst=${uconst}&tconst=${tconst}`, param)
            .then(response => console.log(response.status))
    };


    let getActorBookmarks = (callback) => {
        let param = { 
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM5MDAxNzUxLCJleHAiOjE2MzkwMDM1NTEsImlhdCI6MTYzOTAwMTc1MX0.mCpuQb_Etpcz185Itx86h2JMvBJgnFefWWHCZaMW91g'
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
