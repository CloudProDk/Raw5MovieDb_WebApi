
define(['knockout', 'postman','bookmarkService', 'viewmodel','movieService','actorService'], function (ko, postman, bs, vm, ms, as) {
    return function (params) {

        let token = ko.observable('');
        let userName = ko.observable('');
        let uconst = ko.observable('');
        let movie = ko.observable('');
        let actors = ko.observable('')

      
        token(vm.bearerToken())
        userName(vm.userName())
        uconst(vm.uconst())


        let bookmarks = ko.observableArray([]);
        let actorbookmarks = ko.observableArray([]);

        let deltitle = title => {
            bookmarks.remove(title);
            console.log(title.tconst)
            bs.deleteTitleBookmark(title, uconst, title.tconst);
        }


        //
        let goToMovieByTconst = title => {
            setTimeout(navigateToMovie(title), 1000)
        }

        let navigateToMovie = title => {
            console.log(title.tconst)
            ms.getMovieByTconst(movie, title.tconst)
            vm.currentmovie(movie)
            setTimeout(setCurrentMovie, 3000)
            // CONTINUE WHEN MOVIES AND ACTORS ARE SET UP
            vm.activeView('details')
        }

        let goToActorByNconst = actor => {
            setTimeout(navigateToActor(actor), 1000)
        }
        let navigateToActor = actor => {
            console.log(actor.nconst)
            as.getActorByNconst(actors, actor.nconst)
            vm.currentmovie(actors)
            setTimeout(setCurrentActor, 3000)
            // CONTINUE WHEN MOVIES AND ACTORS ARE SET UP
            vm.activeView('details')
        }

        function setCurrentMovie() {
            console.log(vm.currentmovie())
        }
        function setCurrentActor() {
            console.log(vm.currentactor())
        }

        let delactor = actor => {
            bookmarks.remove(actor);
            console.log(actor.nconst)
            bs.deleteTitleBookmark(actor, nconst, actor.nconst);
        }

        bs.getBookmarks(bookmarks)
        bs.getActorBookmarks(actorbookmarks)

        return {

            bookmarks,
            deltitle,
            actorbookmarks,
            delactor,
            token,
            userName,
            uconst,
            goToMovieByTconst,
            goToActorByNconst,


        };
    };
});

