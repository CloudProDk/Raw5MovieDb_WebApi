define(['viewmodel'], function (vm) {

   

    let getMovies = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
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
            .then(json => callback(json))


    };

    return {
        getMovies,
        getMovieByTconst

    }
});
