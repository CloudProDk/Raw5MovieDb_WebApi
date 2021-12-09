define(["knockout", "postman"], function (ko, postman) {

<
    let currentView = ko.observable("home");
    let amount = ko.observable("hej");

    let activeView =  ko.observable('list-categories')

    let bearerToken = ko.observable('');
    let userName = ko.observable('')
    let uconst = ko.observable('')
    


    let isActive = menuItem => {
        return menuItem.component === currentView() ? "active" : "";
    }

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });

    return {
        activeView,
        isActive,
        bearerToken,
        userName,
        uconst
    }
});
