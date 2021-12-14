define(['knockout', 'postman', 'viewmodel', 'movieService'], function (ko, postman, vm, ms) {
  return function (params) {
    let title = ko.observable(null);
    let actors = ko.observable(null);

    let navigateToActor = actor => {
        vm.currentactor(actor)
        vm.activeView('singleActor')
    }

    if (vm.curTitle().url) {
        ms.getTitle(vm.curTitle().url, title);
        ms.getTitleActors(vm.curTitle().actors, actors);
    } else {
        ms.getMovieByTconst(title, vm.curTitle().tconst);
        setTimeout(loadActors, 1000);
    }

    function loadActors() {
        ms.getTitleActors(title().actors, actors);
        actors.subscribe(function() {
          console.log(actors());
        });
    }

    return {
      title,
      actors,
      navigateToActor
    };
  };
});
