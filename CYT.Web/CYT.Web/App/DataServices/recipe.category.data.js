(function () {
    'use strict'

    angular.module("app.data")
        .factory("RecipeCategoryData", RecipeCategoryData);

    RecipeCategoryData.$inject = ['$resource'];

    function RecipeCategoryData($resource) {
        return $resource("/api/recipecategories/:id", {}, {
            // custom webApi call functions
            
        });
    }

})();