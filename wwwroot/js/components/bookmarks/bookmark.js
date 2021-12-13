
define(['knockout', 'postman','bookmarkService', 'viewmodel'], function (ko, postman, bs, vm) {
    return function (params) {
        let token = ko.observable('');
        let userName = ko.observable('');
        let uconst = ko.observable('');
        let loggedInUser = ko.observable('');

      
        token(vm.bearerToken());
        userName(vm.userName());
        uconst(vm.uconst());
        loggedInUser(vm.loggedInUser());


        let bookmarks = ko.observableArray([]);
        let actorbookmarks = ko.observableArray([]);

        let deltitle = title => {
            bookmarks.remove(title);
            bs.deleteTitleBookmark(title, '1', 'tt7366338' );
        }
        let delactor = actor => {
            actorbookmarks.remove(actor);
            bs.deleteActorBookmark(actor);
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
            loggedInUser
        };
    };
});