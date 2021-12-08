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
    ko.components.register("navigation_bar", {
        viewModel: { require: "components/navigation_bar/navigation_bar" },
        template: { require: "text!components/navigation_bar/navigation_bar.html" }
    });
});

require(["knockout", "viewmodel"], function (ko, vm) {
    //console.log(vm.firstName);

    ko.applyBindings(vm);

});