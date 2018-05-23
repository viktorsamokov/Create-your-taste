(function () {
    'use strict';

    var core = angular.module('app.core');

    core.config(configure);

    configure.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider'];

    function configure($stateProvider, $locationProvider, $urlRouterProvider) {

        

        $urlRouterProvider.otherwise("/main");

        $locationProvider.html5Mode({ enabled: true, requireBase: false });

        // here config the states
        $stateProvider
         .state('manage', {
             url: '/Manage',
             templateUrl: '/Manage/Index'
         });
        $stateProvider
         .state('changePassword', {
             url: '/Manage/ChangePassword',
             templateUrl: '/Manage/ChangePassword'
         });
        $stateProvider
         .state('info', {
             url: '/Account/Info',
             templateUrl: '/Account/Info'
         });
        $stateProvider
         .state('register', {
             url: '/Account/Register',
             templateUrl: '/Account/Register'
         });
        $stateProvider
         .state('login', {
             url: '/Account/Login',
             templateUrl: '/Account/Login'
         });

        $stateProvider
         .state('main', {
             url: "/main",
             templateUrl: 'App/Main/index.html',
             controller: 'MainController',
             controllerAs: 'vm'
         });

        $stateProvider
         .state('search', {
             url: "/search",
             templateUrl: 'App/SearchRecipes/index.html',
             controller: 'SearchController',
             controllerAs: 'vm'
         });

        $stateProvider
         .state('administrator', {
             url: "/administrator",
             templateUrl: 'App/Administrator/index.html',
             controller: 'AdministratorController',
             controllerAs: 'vm'
         });

        $stateProvider
         .state('admin', {
             url: "/admin",
             templateUrl: 'App/UserAdmin/index.html',
             controller: 'UserAdminController',
             controllerAs: 'vm'
         });

        $stateProvider
         .state('user', {
             url: '/user/:id',
             templateUrl: '/App/User/index.html',
             controller: 'UserController',
             controllerAs: 'vm'
         });

        $stateProvider
         .state('recipe', {
             url: '/recipe/:id',
             templateUrl: '/App/Recipe/index.html',
             controller: 'RecipeController',
             controllerAs: 'vm'
         });

    }
})();