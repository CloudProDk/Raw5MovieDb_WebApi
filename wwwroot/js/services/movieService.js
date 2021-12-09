define(['viewmodel'], function (vm) {

    let param = {
        headers: {
            "Content-Type": "application/json",
            'Authorization': 'Bearer ' + vm.bearerToken()
        }
    }

    let getMovies = (callback) => {
        fetch("api/titles?Page=10&PageSize=50", param)
            .then(response => response.json())
            .then(json => callback(json))

    };



    let getMovieByTconst = (callback, tconst) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }   
        fetch(`/api/titles/${tconst}`, param)
            .then(response => response.json())
            .then(json => console.log(json))

    };

    return {
        getMovies,
        getMovieByTconst

    }
});
