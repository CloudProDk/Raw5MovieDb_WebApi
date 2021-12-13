define(['knockout', 'postman', 'viewmodel', 'movieService'], function (ko, postman, vm, ms) {
  return function (params) {
    let title = ko.observable(null);
    let actors = ko.observable(null);
    ms.getTitle(vm.curTitle().url, title);
    ms.getTitleActors(vm.curTitle().actors, actors);
    return {
      title,
      actors
    };
  };
});
