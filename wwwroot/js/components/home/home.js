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

    let loadPreviousTitlePage = (titleCollection) => {
      console.log(titleCollection().previousPage);
      ms.getTitlesFromUrl(titleCollection().previousPage, titleCollection);
    }

    let loadNextTitlePage = (titleCollection) => {
      console.log(titleCollection().nextPage);
      ms.getTitlesFromUrl(titleCollection().nextPage, titleCollection);
    }

    return {
      popularTitles,
      actionTitles,
      scifiTitles,
      goToTitleDetails,
      loadPreviousTitlePage,
      loadNextTitlePage
    };
  };
});
