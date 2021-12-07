define(['knockout', 'postman', 'movieService'], function (ko, postman, ms) {
    return function (params) {

        let movies = ko.observableArray([]);
       
        ms.getMovies(movies);

       

        // postman.subscribe("newCategory", category => {
        //     ds.createCategory(category, newCategory => {
        //         categories.push(newCategory);
        //     });
        // }, "list-categories");

        return {
            
            movies,
            
        };
    };
});