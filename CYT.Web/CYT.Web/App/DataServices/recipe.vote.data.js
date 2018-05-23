(function () {
    'use strict'

    angular.module("app.data")
        .factory("RecipeVoteData", RecipeVoteData);

    RecipeVoteData.$inject = ['$resource'];

    function RecipeVoteData($resource) {
        return $resource("/api/recipevotes/:id", {}, {
            // custom webApi call functions
            'update' :
            {
                method: 'PUT'
            },
            'userVote' :{
                method: 'GET',
                url: "/api/recipe/votes/:recipeId/:userId",
                isArray: true
            }
            
        });
    }

})();