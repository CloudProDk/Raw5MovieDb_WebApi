define(['knockout', 'postman', 'viewmodel'], function (ko, postman, vm) {
    return function (params) {
        let token = ko.observable('');
        let userName = ko.observable('');
        let uconst = ko.observable('');

        token(vm.bearerToken())
        userName(vm.userName())
        uconst(vm.uconst())
        
        
        return {
            token,
            userName,
            uconst
        }
    };
});