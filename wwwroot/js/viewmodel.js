define(["knockout", "postman"], function (ko, postman) {


    let activeView =  ko.observable('list-categories')

    let bearerToken = ko.observable('');
    let userName = ko.observable('')
    let uconst = ko.observable('')
    let loggedInUser = ko.observable('')
    let navigationBarVisible = ko.observable(false)
    let currentmovie = ko.observable('');
    let currentactor = ko.observable('');
    
    // Navigation Bar Items
    let menuItems = [
        { title: "Home", component: "home" },
        { title: "Movies", component: "movieList" },
        { title: "Series", component: "details" },
        { title: "Bookmarks", component: "bookmark" },
    ];

    //Change Navigation
    let changeContent = menuItem => {
        console.group(menuItem)
        activeView(menuItem.component)
    };

    //Change View Icons
    let changeView = page => {
        console.log(page);
        activeView(page);
    }


    // Active route
    let isActive = menuItem => {
        return menuItem.component === currentView() ? "active" : "";
    }
    
    postman.subscribe("changeView", function (data) {
        currentView(data);
    });

    return {
        activeView,
        bearerToken,
        userName,
        uconst,

        currentmovie,
        currentactor

        loggedInUser,
        navigationBarVisible,
        menuItems,
        changeContent,
        isActive,
        changeView,

    }
});
