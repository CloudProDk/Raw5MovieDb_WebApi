define([], () => {

    let getMovies = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjkiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4OTY4NDY3LCJleHAiOjE2Mzg5NzAyNjcsImlhdCI6MTYzODk2ODQ2N30.77XShd3yZSUNfjHM9gpOvWC351CNGEUYa8ucthnpsUs'
            }
        }
        fetch("api/titles?Page=10&PageSize=10", param)

            .then(response => response.json())
            .then(json => callback(json))

    };

    return {
        getMovies
    }
});

