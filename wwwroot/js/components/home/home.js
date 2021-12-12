define(['knockout', 'postman', 'viewmodel', 'movieService'], function (ko, postman, vm, ms) {
  return function (params) {
    let popularTitles = ko.observableArray([]);
    let actionTitles = ko.observableArray([]);
    let scifiTitles = ko.observableArray([]);
    ms.getPopularTitles(popularTitles);
    ms.getTitlesFromGenre(6, actionTitles);
    ms.getTitlesFromGenre(11, scifiTitles);

    let goToTitleDetails = titleItem => {
      // console.group(titleItem);
      vm.curTitle(titleItem);
      vm.activeView('details');
    };

    return {
      popularTitles,
      actionTitles,
      scifiTitles,
      goToTitleDetails
    };
  };
});
