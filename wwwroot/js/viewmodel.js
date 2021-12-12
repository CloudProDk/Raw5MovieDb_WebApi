define(["knockout", "postman"], function (ko, postman) {

    let activeView = ko.observable('list-categories');

    let bearerToken = ko.observable('');
    let userName = ko.observable('');
    let uconst = ko.observable('');
    let curTitle = ko.observable(null);

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
        uconst,
        curTitle
    }
});
