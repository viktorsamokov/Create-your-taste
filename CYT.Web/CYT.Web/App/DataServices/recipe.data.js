(function () {
    'use strict'

    angular.module("app.data")
        .factory("RecipeData", RecipeData);

    RecipeData.$inject = ['$resource'];

    function RecipeData($resource) {
        return $resource("/api/recipes/:id", {}, {
            // custom webApi call functions
            'update': {
                method: 'PUT',
            },
            'getRecipe': {
                method: 'GET',
                url: "/api/recipe/:recipeId",
                isArray:true
            },
            'getSimilarRecipes': {
                method: 'GET',
                url: "/api/similar/recipes/:recipeId",
                isArray:true
            },
            'getUserRecipes': {
                method: 'GET',
                url: "/api/user/recipes/:id",
                isArray: true
            },
            'getUserAdminRecipes': {
                method: 'GET',
                url: "/api/user/recipes/admin/:id",
                isArray: true
            },
            'getAllRecipes': {
                method: 'GET',
                url: "/api/all/recipes",
                isArray: true
            },
            'recipeUpdate': {
                method: 'POST',
                url: "/api/recipe/update/:recipeId"
            },
            'searchRecipesCategory': {
                method: 'POST',
                url: "/api/search/recipes/category",
                isArray: true
            },
            'searchRecipes': {
                method: 'POST',
                url: "/api/search/recipes",
                isArray: true
            }
            
        });
    }

})();