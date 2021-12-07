define([], () => {

    let getMovies = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4OTA4MzA5LCJleHAiOjE2Mzg5MTAxMDksImlhdCI6MTYzODkwODMwOX0.ne5_VRKJ7PLN0UmK7bO1Rfve-Na_MezZ91t9EbuhGuU'
            }
        }
        fetch("api/titles?Page=10&PageSize=10", param)
        
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getMovies
    }
});

