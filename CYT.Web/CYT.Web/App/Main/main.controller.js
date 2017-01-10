(function () {
    'use strict'

    angular
        .module("app.main")
        .controller("MainController", MainController);

    MainController.$inject = [];

    function MainController() {
        var vm = this;
        vm.test = "test";

        vm.fruits = ["Apple", "Banana", "Peach", "Orange"];
        vm.proba;
    }
})()