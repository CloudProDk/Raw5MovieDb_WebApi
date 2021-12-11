define(['knockout', 'postman', 'movieService'], function (ko, postman, ms) {
  return function (params) {
    let popularTitles = ko.observableArray([]);
    let actionTitles = ko.observableArray([]);
    let scifiTitles = ko.observableArray([]);
    ms.getPopularTitles(popularTitles);
    ms.getTitlesFromGenre(6, actionTitles);
    ms.getTitlesFromGenre(11, scifiTitles);

    return {
      popularTitles,
      actionTitles,
      scifiTitles
    };
  };
});
