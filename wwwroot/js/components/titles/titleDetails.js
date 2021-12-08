define(['knockout', 'postman', 'movieService'], function (ko, postman, ms) {
  return function (params) {
    let movies = ko.observableArray([]);
    ms.getMovies(movies);

    console.log(movies);

    return {
      movies
    };
  };
});
