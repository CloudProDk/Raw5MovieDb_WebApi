define(['knockout', 'postman', 'movieService'], function (ko, postman, ms) {
  return function (params) {
    let title = ko.observable(null);
    let actors = ko.observable(null);
    ms.getTitle('tt3890160', title);
    ms.getTitleActors('tt3890160', actors);
    return {
      title,
      actors
    };
  };
});
