define(['knockout', 'postman', 'movieService'], function (ko, postman, ms) {
  return function (params) {
    let popularTitles = ko.observableArray([]);
    let actionTitles = ko.observableArray([]);
    ms.getPopularTitles(popularTitles);
    ms.getTitlesFromGenre(6, actionTitles);

    return {
      popularTitles,
      actionTitles
    };
  };
});
