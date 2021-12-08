define([], () => {

    let getMovies = (callback) => {

        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4OTAxODAzLCJleHAiOjE2Mzg5MDM2MDMsImlhdCI6MTYzODkwMTgwM30.PGuYUCIm2dRmZiCHntn1KdgImxxjCNOB2IKmaW102Hk'
            }
        }

        fetch("api/titles?Page=10&PageSize=10", param)

            .then(response => response.json())
            .then(json => console.log(json));

    };

    return {
        getMovies
    }
});
