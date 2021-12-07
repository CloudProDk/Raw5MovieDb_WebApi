define(['knockout', 'postman','bookmarkService'], function (ko, postman, bs) {
    return function (params) {


        let bookmarks = ko.observableArray([]);
        let actorbookmarks = ko.observableArray([]);

        bs.getBookmarks(bookmarks)
        bs.getActorBookmarks(actorbookmarks)

        return {

            bookmarks,
            actorbookmarks
        };
    };
});