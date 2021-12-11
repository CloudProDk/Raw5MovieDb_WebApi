define(['knockout', 'postman','viewmodel','actorService'], function (ko, postman, vm, as) {
    return function (params) {

        console.log(vm.currentactor().nconst)
        console.log(vm.currentactor())
        let actor = vm.currentactor().nconst

        let actorresult = ko.observable('')

        as.getActorByNconst(actorresult, vm.currentactor().nconst)

        console.log(actorresult().url)
        
        return {
            actor,
            actorresult
        }
    };
});