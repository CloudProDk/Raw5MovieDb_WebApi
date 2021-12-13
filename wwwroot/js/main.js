/// <reference path="lib/jquery/dist/jquery.min.js" />
/// <reference path="lib/requirejs/text.js" />
/// <reference path="lib/knockout/build/output/knockout-latest.debug.js" />


require.config({
    baseUrl: 'js',
    paths: {
        text: "lib/requirejs/text",
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        movieService: "services/movieService",
        bookmarkService: "services/bookmarkService",
        authenticationService: "services/authenticationService",
        postman: "services/postman",
        actorService: "services/actorService",
        searchService: "services/searchService"

    }
});

// component registration
require(['knockout'], (ko) => {
    ko.components.register("add-category", {
        viewModel: { require: "components/categories/addCategory" },
        template: { require: "text!components/categories/addCategory.html" }
    });
    ko.components.register("list-categories", {
        viewModel: { require: "components/categories/listCategories" },
        template: { require: "text!components/categories/listCategories.html" }
    });
    ko.components.register("login", {
        viewModel: { require: "components/login/login" },
        template: { require: "text!components/login/login.html" }
    });
    ko.components.register("bookmark", {
        viewModel: { require: "components/bookmarks/bookmark" },
        template: { require: "text!components/bookmarks/bookmark.html" }
    });

    ko.components.register("movieList", {
        viewModel: { require: "components/movieList/movieList" },
        template: { require: "text!components/movieList/movieList.html" }
    });
    ko.components.register("singleActor", {
        viewModel: { require: "components/singleActor/singleActor" },
        template: { require: "text!components/singleActor/singleActor.html" }
    });

    ko.components.register("navigation_bar", {
        viewModel: { require: "components/navigation_bar/navigation_bar" },
        template: { require: "text!components/navigation_bar/navigation_bar.html" }
    });
    ko.components.register("home", {
      viewModel: { require: "components/home/home" },
      template: { require: "text!components/home/home.html" }
    });
    ko.components.register("details", {
      viewModel: { require: "components/titles/titleDetails" },
      template: { require: "text!components/titles/titleDetails.html" }

    });
    ko.components.register("search", {
        viewModel: { require: "components/search/search" },
        template: { require: "text!components/search/search.html" }

    });

});

require(["knockout", "viewmodel"], function (ko, vm) {
    //console.log(vm.firstName);

    ko.applyBindings(vm);

});
