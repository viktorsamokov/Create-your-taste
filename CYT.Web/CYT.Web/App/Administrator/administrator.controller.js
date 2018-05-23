(function () {
    'use strict'

    angular
        .module("app.administrator")
        .controller("AdministratorController", AdministratorController);

    AdministratorController.$inject = ['$state', '$uibModal', 'UserData', 'RecipeData'];

    function AdministratorController($state, $uibModal, UserData, RecipeData) {
        var vm = this;
        
        UserData.administratorPanel(callback);
        vm.users = UserData.query()
        vm.recipes = RecipeData.getAllRecipes();
        vm.save = save;
        vm.approveRecipe = approveRecipe;
        vm.disableRecipe = disableRecipe;
        vm.viewRecipe = viewRecipe;

        function callback(data){
            if (data[0] == "False") {
                $state.go("main");
            }
        }
        
        function disableRecipe(recipe) {
            recipe.RecipeStatus = 2;
            RecipeData.recipeUpdate({ recipeId: false }, recipe, function (data) {
                console.log(data);
                for (var i = 0; i < vm.recipes.length; i++) {
                    console.log(vm.recipes[i]);
                    if (vm.recipes[i].RecipeId == data.RecipeId) {
                        console.log("in")
                        vm.recipes[i] = data;
                    }
                }
            })
        }

        function approveRecipe(recipe) {
            recipe.RecipeStatus = 1;
            RecipeData.recipeUpdate({ recipeId: true }, recipe, function (data) {
                console.log(data);
                for (var i = 0; i < vm.recipes.length; i++) {
                    console.log(vm.recipes[i]);
                    if (vm.recipes[i].RecipeId == data.RecipeId) {
                        console.log("in")
                        vm.recipes[i] = data;
                    }
                }
            })
        }

        function save(user) {
            UserData.update({id: user.UserId}, user, function (data) {
            });
        }

        function viewRecipe(recipe, size) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'myModal.html',
                controller: 'MyModalCtrl',
                controllerAs: 'vm',
                size: size,
                backdrop: 'false',
                resolve: {
                    recipe: function () {
                        return angular.copy(recipe);
                    }
                }
            });

            modalInstance.result.then(function (data) {
                if (data) {
                    console.log(data);
                }
            }, function () {
                console.log('Modal dismissed at: ' + new Date());
            });
        }
    }
})()