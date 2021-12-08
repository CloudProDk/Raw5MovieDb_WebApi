define(["knockout", "postman"], function (ko, postman) {
    
    let activeView =  ko.observable('list-categories')
    let bearerToken = ko.observable('');



    let isActive = menuItem => {
        return menuItem.component === currentView() ? "active" : "";
    }

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });
    
    return {
        activeView,
        isActive,
    }
});