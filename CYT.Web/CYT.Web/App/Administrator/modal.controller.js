(function () {
    'use strict'

    angular
        .module("app.administrator")
        .controller("MyModalCtrl", MyModalCtrl);

    MyModalCtrl.$inject = ['$uibModalInstance', '$scope', 'recipe', 'RecipeCategoryData'];

    function MyModalCtrl($uibModalInstance, $scope, recipe, RecipeCategoryData) {
        var vm = this;
        console.log(recipe);

        vm.imagesNumber = recipe.RecipeImages.length;
        vm.categories = RecipeCategoryData.query();
        vm.hours = 0;
        vm.minutes = 0;
        if (recipe.PreparationTime > 60) {
            vm.hours = parseInt(recipe.PreparationTime / 60);
            vm.minutes = recipe.PreparationTime % 60;
        }
        else {
            vm.minutes = recipe.PreparationTime;
        }
        vm.recipe = recipe;
        vm.ingredientQuantity = "";
        vm.ingredientName = "";
        vm.cancel = cancel;

        function cancel() {
            $uibModalInstance.close();
        }

    }
})()