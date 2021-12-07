define([], () => {

    let getBookmarks = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4OTA1MDE2LCJleHAiOjE2Mzg5MDY4MTYsImlhdCI6MTYzODkwNTAxNn0.YFDRQLSqmjXKsagSRP8mKCijYnz6WisDod8aBTetcgQ'
            }
        }
        fetch("/api/Bookmark/TitleBookmark/1", param)
            .then(response => response.json())
            .then(json => callback(json));

    };

    let getActorBookmarks = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4OTA1MDE2LCJleHAiOjE2Mzg5MDY4MTYsImlhdCI6MTYzODkwNTAxNn0.YFDRQLSqmjXKsagSRP8mKCijYnz6WisDod8aBTetcgQ'
            }
        }
        fetch("/api/Bookmark/ActorBookmark/1", param)
            .then(response => response.json())
            .then(json => callback(json));

    };


    return {
        getBookmarks,
        getActorBookmarks
    }
});