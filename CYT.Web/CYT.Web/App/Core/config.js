﻿(function () {
    'use strict';

    var core = angular.module('app.core');

    core.config(configure);

    configure.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider'];

    function configure($stateProvider, $locationProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/main");

        $locationProvider.html5Mode({ enabled: true, requireBase: false });

        // here config the states
        $stateProvider
         .state('main', {
             url: "/main",
             templateUrl: 'App/Main/index.html',
             controller: 'MainController',
             controllerAs: 'vm'
         });

        $stateProvider
         .state('user', {
             url: '/user/:id',
             templateUrl: '/App/User/index.html',
             controller: 'UserController',
             controllerAs: 'vm'
         });

    }
})();