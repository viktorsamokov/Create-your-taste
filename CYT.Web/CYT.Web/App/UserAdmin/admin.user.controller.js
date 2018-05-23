(function () {
    'use strict'

    angular
        .module("app.admin.user")
        .controller("UserAdminController", UserAdminController);

    UserAdminController.$inject = ['$stateParams', '$state', '$scope', '$uibModal', 'UserData', 'FileUploader', 'RecipeData', 'RecipeCategoryData'];

    function UserAdminController($stateParams, $state, $scope, $uibModal, UserData, FileUploader, RecipeData, RecipeCategoryData) {
        var vm = this;

        var recipeId;
        var userId;
        vm.user = UserData.isLoggedIn(callback);
        vm.categories = RecipeCategoryData.query();
        vm.userRecipes;
        vm.favoriteRecipes;
        vm.noFavoriteRecipes = false;
        vm.noRecipes = false;
        
        // my details part
        vm.click = click;
        vm.changePassword = changePassword;
        vm.update = update;
        vm.canUpload = false;
        vm.changePasswordViewModel = {};
        vm.check = check;
        vm.result;
        

        vm.passwordChanged = {
            changed: false,
            message: ""
        };

        vm.incorrectPassword = {
            incorrect: false,
            message: ""
        };

        vm.user.$promise.then(function () {
            userId = vm.user.UserId;
            vm.userRecipes = RecipeData.getUserAdminRecipes({ id: userId }, function (data) {
                if (data.length == 0) {
                    vm.noRecipes = true;
                }
            });
            vm.favoriteRecipes = UserData.getFavoriteRecipes({ userId: userId }, function (data) {
                console.log(data);
                if(data.length==0)
                {
                    vm.noFavoriteRecipes = true;
                }
            });
            vm.uploader = createUploader(vm.user);
            vm.canUpload = true;
            vm.uploader.filters.push({
                name: 'imageFilter',
                fn: function (item /*{File|FileLikeObject}*/, options) {
                    var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                    return '|jpg|png|jpeg|bmp|gif|'.indexOf(type) !== -1;
                }
            });
        })

        ////////////////////////////////////////

        function check() {

            vm.result = angular.equals(vm.changePasswordViewModel.NewPassword, vm.changePasswordViewModel.ConfirmPassword);
        }

        function changePassword() {
            UserData.changeUserPassword(vm.changePasswordViewModel, function (data) {
                if (data.StatusType == 0) {
                    vm.passwordChanged.changed = true;
                    vm.passwordChanged.message = data.Status;
                    vm.changePasswordViewModel = {}
                    vm.incorrectPassword.incorrect = false;
                }
                else if (data.StatusType == 1) {
                    vm.passwordChanged.changed = false;
                    vm.incorrectPassword.incorrect = true;
                    vm.incorrectPassword.message = data.Status;

                }
                else if (data.StatusType == 2) {
                    vm.incorrectPassword.incorrect = false;
                    vm.passwordChanged.changed = false;
                    vm.result = false;
                }
            })
        }

        function click() {
            $('#Logo').click();
        }

        function callback(data) {
            if (data[0] == "False") {
                $state.go("main");
            }
            vm.user = data[0];
        };

        function update() {
            UserData.update({ id: vm.user.UserId }, vm.user, function (data) {
                vm.user = data;
            });
        }

        function createUploader(user) {
            return new FileUploader({
                url: "/api/upload/profile/user/" + user.UserId,
                removeAfterUpload: false,
                autoUpload: false,
                queueLimit: 1,
                onAfterAddingFile: function (item) {
                },
                onSuccessItem: function (item, response, status, headers) {
                    vm.uploader.queue = [];
                    vm.user = response;
                },
                onSuccess: function (response, status, headers) { },
                onComplete: function (response, status, headers) { }
            });
        }

        /////////////////////////////////////////////////////

        // upload recipe part
        vm.recipe = new RecipeData();
        vm.showVideoForm = false;
        vm.success = false;
        vm.hours = 0;
        vm.minutes = 0;
        vm.uploadRecipe = uploadRecipe;
        vm.favoriteRecipe = favoriteRecipe;
        vm.ingredientName ="";
        vm.ingredientQuantity = "";
        vm.ingredients = [];
        vm.addIngredient = addIngredient;
        vm.removeIngredient = removeIngredient;
        vm.attachRecipeImages = attachRecipeImages;
        vm.recipeImageUploader = recipeImageUploader();
        vm.tempImages = [];

        function attachRecipeImages() {
            $('#recipeImages').click();
        }

        function removeIngredient(arr, index) {
            arr.splice(index, 1);
        }

        function addIngredient() {
            var Ingredient = {};

            Ingredient.Name = vm.ingredientName;
            Ingredient.Quantity = vm.ingredientQuantity;

            vm.ingredients.push(Ingredient);
            vm.ingredientName = "";
            vm.ingredientQuantity = "";
        }

        function uploadRecipe() {
            vm.recipe.PreparationTime = vm.hours * 60 + vm.minutes;
            vm.recipe.Ingredients = vm.ingredients;

            RecipeData.save(vm.recipe, function (data) {
                recipeId = data.RecipeId;
                vm.userRecipes.push(data);
                vm.recipeImageUploader.uploadAll();
                console.log(data);
                
                console.log(vm.userRecipes);
            })
        }
        function favoriteRecipe(recipeId) {
            UserData.favoriteRecipe(recipeId, vm.user.UserId, function (data) {
                console.log(data);
            });
        }

        function recipeImageUploader() {
            return new FileUploader({
                url: "/api/upload/recipes/",
                removeAfterUpload: false,
                autoUpload: false,
                queueLimit: 4,
                onAfterAddingFile: function (item) {
                },
                onBeforeUploadItem: function(item) {
                    item.url = '/api/upload/recipes/image/' + recipeId + "/" + vm.user.UserId;
                },
                onSuccessItem: function (item, response, status, headers) {
                    vm.tempImages.push(response);
                    console.log(vm.tempImages);
                },
                onSuccess: function (response, status, headers) { },
                onCompleteAll: function () {
                    console.log(vm.tempImages);
                    for (var i = 0; i < vm.userRecipes.length; i++) {
                        console.log(vm.userRecipes[i].RecipeId, recipeId)
                        if (vm.userRecipes[i].RecipeId == recipeId) {
                            console.log("in");
                            vm.userRecipes[i].RecipeImages = vm.tempImages;
                        }
                    }
                    console.log(vm.userRecipes);
                    vm.tempImages = [];
                    vm.success = true;
                    vm.recipe = new RecipeData();
                    vm.hours = 0;
                    vm.minutes = 0;
                    vm.ingredients = [];
                    vm.recipeImageUploader.queue = [];
                    $scope.uploadRecipe.$setPristine();
                    $scope.uploadRecipe.$setUntouched();
                }
            });
        }

        ///////////////////////////////////////////

        // user recipes part

        vm.removeRecipe = removeRecipe;
        vm.editRecipe = editRecipe;
        

        function removeRecipe(recipe, index) {
            console.log(recipe);
            RecipeData.delete({id: recipe.RecipeId}, function(data){
                console.log(data);
                vm.userRecipes.splice(index, 1);
            })
        }

        function editRecipe(recipe, size) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
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
                    for (var i = 0; i < vm.userRecipes.length; i++)
                    {
                        if (data.RecipeId == vm.userRecipes[i].RecipeId) {
                            vm.userRecipes[i] = data;
                        }
                    }
                    recipe = data;
                }
            }, function () {
                console.log('Modal dismissed at: ' + new Date());
            });
        }

        ////////////// 
        // favorite recipes

        vm.removeFavoriteRecipe = removeFavoriteRecipe;

        function removeFavoriteRecipe(recipe, index) {
            UserData.removeFavoriteRecipe({recipeId : recipe.RecipeId, userId: vm.user.UserId}, function (data) {
                vm.favoriteRecipes.splice(index, 1);
            })
        }


    }
})()