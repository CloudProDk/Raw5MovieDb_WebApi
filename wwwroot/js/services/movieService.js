define([], () => {

    let getMovies = (callback) => {
        
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4ODg1ODA2LCJleHAiOjE2Mzg4ODc2MDYsImlhdCI6MTYzODg4NTgwNn0.lExtHfhWx453x-XEzMXJb7xmgRI2F8vF24I2dyAA_vQ'
            }
        }
        
        fetch("api/titles?Page=10&PageSize=50", param)
        
            .then(response => response.json())
            .then(json => callback(json));

    };

    return {
        getMovies
    }
});

