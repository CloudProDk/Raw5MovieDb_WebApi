define(['viewmodel'], (vm) => {

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

  let getPopularTitles = (callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch("api/titles/popular", param)
      .then(response => response.json())
      .then(json => callback(json))
  };

  let getTitlesFromGenre = (genreid, callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch(`api/genres/${genreid}/titles`, param)
      .then(response => response.json())
      .then(json => callback(json))
  };

  let getTitle = (tconst, callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch(`api/titles/${tconst}`, param)
      .then(response => response.json())
      .then(json => {callback(json); console.log(json)})
  };

  let getTitleActors = (tconst, callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch(`api/titles/${tconst}/actors`, param)
      .then(response => response.json())
      .then(json => {callback(json); console.log(json)})
  };

  return {
    getMovies,
    getPopularTitles,
    getTitlesFromGenre,
    getTitle,
    getTitleActors
  }
});
