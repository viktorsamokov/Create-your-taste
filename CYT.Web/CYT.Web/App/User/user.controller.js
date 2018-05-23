(function () {
    'use strict'

    angular
        .module("app.user")
        .controller("UserController", UserController);

    angular.module("app.user").filter('floor', function () {
        return function (input) {
            return Math.floor(input);
        };
    });

    UserController.$inject = ['$stateParams','UserData','RecipeData'];

    function UserController($stateParams, UserData, RecipeData) {
        var vm = this;
        vm.difficulties = ["Easy", "Medium", "Advanced"];
        vm.user = UserData.getUser({ userId: $stateParams.id }, callback);


        vm.user.$promise.then(function () {
            vm.recipes = RecipeData.getUserRecipes({ id: vm.user.UserId }, function (data) {
                if (data.length == 0) {
                    vm.noRecipes = true;
                }
            });
            vm.favoriteRecipes = UserData.getFavoriteRecipes({ userId: vm.user.UserId }, function (data) {
                console.log(data);
                if (data.length == 0) {
                    vm.noFavoriteRecipes = true;
                }
            });
        })
        function callback(data) {
            console.log(data);
            if (!data)
                $state.go("main");

            vm.user = data;
            
            //angular.forEach(vm.user.Recipes, function (value, key) {
            //    vm.recipees.push(RecipeData.getRecipe({ recipeId: vm.user.Recipes[key].RecipeId }, callback1));
            //    var promise = vm.recipees[key]['$promise'];
            //    promise.then(function (res) {
            //        for (var i = 0; i < res.length; i++)
            //            vm.recipes.push(res[i]);
            //    }, function (reason) {
            //        alert('Failed: ' + reason);
            //    });
            //});
            

            //function callback1(data) {
            //    if (!data)
            //        $state.go("main");

            //    vm.recipe = data[0];
            //    if (vm.recipe.Difficulty == 0) {
            //        vm.difficulty = "Easy"
            //    }
            //    else if (vm.recipe.Difficulty == 1) {
            //        vm.difficulty = "Medium"
            //    }
            //    else if (vm.recipe.Difficulty == 2) {
            //        vm.difficulty = "Advanced"
            //    }
            //    if (vm.recipe.PreparationTime > 60) {
            //        vm.hour = Math.floor(vm.recipe.PreparationTime / 60)
            //        vm.minutes = vm.recipe.PreparationTime % 60;
            //    }
            //    //console.log(vm.recipe);
            //};
            //console.log(vm.user);

            
        };
        //console.log(vm.user);
    }
})()