define(['knockout', 'postman','bookmarkService'], function (ko, postman, bs) {
    return function (params) {


        let bookmarks = ko.observableArray([]);
        let actorbookmarks = ko.observableArray([]);

        let deltitle = title => {
            bookmarks.remove(title);
            bs.deleteTitleBookmark(title);
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
            delactor
        };
    };
});