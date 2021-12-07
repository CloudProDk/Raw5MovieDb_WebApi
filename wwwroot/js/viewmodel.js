define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("movieList");
    let amount = ko.observable("hej");
    let bearerToken = ko.observable('');

    let menuItems = [
        {title: "List", component: "list-categories"},
        {title: "Add", component: "add-categories"}
    ];

    let changeContent = menuItem => {
        console.log(menuItem);
        currentView(menuItem.component);
    };

    let isActive = menuItem => {
        return menuItem.component === currentView() ? "active" : "";
    }

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });
    
    return {
        menuItems,
        currentView,
        changeContent,
        isActive,
        amount
    }
});