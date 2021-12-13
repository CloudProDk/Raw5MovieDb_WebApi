define(['knockout', 'viewmodel', 'searchHistoryService'], function (ko, vm, sh) {
    return function (params) {

        let loggedInUser = ko.observable('');
        let searchHistory = ko.observableArray([]);

        loggedInUser(vm.loggedInUser());

        sh.getSearchHistory(searchHistory);

        let changeContent = menuItem => {
            console.group(menuItem)
            vm.activeView(menuItem.component)
        };

        return {
            loggedInUser,
            searchHistory
        }
    };
})