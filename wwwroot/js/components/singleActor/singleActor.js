define(['knockout', 'postman','viewmodel','actorService'], function (ko, postman, vm, as) {
    return function (params) {

        console.log(vm.currentactor().nconst);
        console.log(vm.currentactor());
        let actornconst = vm.currentactor().nconst;


        let actorToBeShown = ko.observableArray([]);

        as.getActorByNconst(actorToBeShown, actornconst);


        console.log(actorToBeShown());
        
        return {
            actorToBeShown
        }
    };
});