define(['knockout', 'authenticationService', 'viewmodel'], function (ko, as, vm) {
    return function (params) {

        let userName = ko.observable('JohnDoe')
        let password = ko.observable('123')
        let token = ko.observable('');


        let login = () => {
            as.authenticate(userName(), password(), token)
            setTimeout(navigate, 1000)

        }

        let navigate = () => {
            if (token().token != '') {
                console.log(token())
                vm.bearerToken(token().token)
                vm.userName(token().userName)
                vm.uconst(token().uconst)
                vm.activeView('movieList')
            } else { console.log('error') }
        }


        return {
            login,
            userName,
            password,
            token

        };


    };
});