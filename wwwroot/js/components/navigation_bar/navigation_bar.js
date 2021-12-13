define(['knockout', 'postman', "viewmodel"], function (ko, postman, vm) {
    return function (params) {

        

        let menuItems = [
            { title: "Home", component: "home" },
            { title: "Movies", component: "movieList" },
            { title: "Series", component: "details" },
            { title: "Bookmarks", component: "bookmark" },
        ];

        let changeContent = menuItem => {
            console.group(menuItem)
            vm.activeView(menuItem.component)
        };

        let changeView = page => {
            console.log(page);
            vm.activeView(page);
        }
    
        let isActive = menuItem => {
            return menuItem.component === currentView() ? "active" : "";
        }

        return {
            menuItems,
            changeContent,
            isActive,
            changeView,
            
        }
    };
})