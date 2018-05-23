(function () {
    'use strict'

    angular.module("app.data")
        .factory("RecipeImageData", RecipeImageData);

    RecipeImageData.$inject = ['$resource'];

    function RecipeImageData($resource) {
        return $resource("/api/recipeimages/:id", {}, {
            // custom webApi call functions

        });
    }

})();