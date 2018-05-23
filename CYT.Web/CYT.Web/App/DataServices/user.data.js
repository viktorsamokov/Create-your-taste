(function () {
    'use strict'

    angular.module("app.data")
        .factory("UserData", UserData);

    UserData.$inject = ['$resource'];

    function UserData($resource) {
        return $resource("/api/users/:id", {}, {
            // custom webApi call functions

            'update': {
                method: 'PUT'
            },

            'administratorPanel': {
                method: 'GET',
                url: '/api/administrator/authentication',
                isArray: true
            },

            'isLoggedIn': {
                method: "GET",
                url: "/api/user/authentication",
                isArray: true
            },

            'changeUserPassword': {
                method: 'POST',
                url: '/api/Users/changeUserPassword'
            },
            'getUser':
            {
                method: 'GET',
                url: "/api/user/:userId"
            },
            'getFavoriteRecipes':
            {
                method: 'GET',
                url: "/api/favorites/user/:userId",
                isArray: true
            },
            'favoriteRecipe':
            {
                method: 'GET',
                url: "/api/favorite/user/:userId/:recipeId",
            },
            'removeFavoriteRecipe':
            {
                method: 'DELETE',
                url: "/api/remove/favourite/recipe/:recipeId/:userId"
            }
        });
    }

})();