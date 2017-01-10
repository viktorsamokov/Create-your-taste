(function () {
    'use strict'

    angular
        .module("app.user")
        .controller("UserController", UserController);

    UserController.$inject = ['$stateParams'];

    function UserController($stateParams) {
        var vm = this;
        

    }
})()