(function () {
    'use strict'

    angular
        .module("app.search")
        .controller("SearchController", SearchController);

    SearchController.$inject = ['RecipeCategoryData', 'RecipeData'];

    function SearchController(RecipeCategoryData, RecipeData) {
        var vm = this;
        
        vm.ingredient = "";
        vm.ingredients = [];
        vm.recipes;
        vm.add = add;
        vm.search = search;
        vm.categoryId = null;
        vm.categories = RecipeCategoryData.query(function(data){console.log(data)})

        function search() {
            console.log(vm.ingredients);
            if (!vm.categoryId) {
                vm.recipes = RecipeData.searchRecipes(vm.ingredients, function (data) { console.log(data) });
            }
            else
                vm.recipes = RecipeData.searchRecipesCategory({ categoryId: vm.categoryId }, vm.ingredients, function (data) { console.log(data)});

            
        }

        function add(ingredient) {
            for (var i = 0; i < vm.ingredients.length; i++) {
                if (angular.equals(vm.ingredients[i], ingredient))
                {
                    vm.ingredient = "";
                    return;
                }
            }
            
            vm.ingredients.push(ingredient);
            vm.ingredient = "";
            console.log(vm.ingredients);
        }
        
    }
})()