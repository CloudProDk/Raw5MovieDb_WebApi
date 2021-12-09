define([], () => {

    let getMovies = (callback) => {

        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4OTkwNjM3LCJleHAiOjE2Mzg5OTI0MzcsImlhdCI6MTYzODk5MDYzN30.E3ghSKRF3fK5wXucNslAkoekltgTwQ2nPwb-qD8mU3g'
            }
        }
        fetch("api/titles?Page=10&PageSize=50", param)




            .then(response => response.json())
            .then(json => callback(json))

    };

    return {
        getMovies
    }
});
