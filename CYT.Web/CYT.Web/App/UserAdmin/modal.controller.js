(function () {
    'use strict'

    angular
        .module("app.recipe")
        .controller("ModalInstanceCtrl", ModalInstanceCtrl);

    ModalInstanceCtrl.$inject = ['$uibModalInstance', '$scope', 'recipe', 'FileUploader', 'RecipeCategoryData', 'RecipeImageData', 'RecipeData'];

    function ModalInstanceCtrl($uibModalInstance, $scope, recipe, FileUploader, RecipeCategoryData, RecipeImageData, RecipeData) {
        var vm = this;
        console.log(recipe);

        vm.imagesNumber = recipe.RecipeImages.length;
        vm.categories = RecipeCategoryData.query();
        vm.recipeImageUploader = recipeImageUploader();
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
        vm.ok = ok;
        vm.cancel = cancel;
        vm.addIngredient = addIngredient;
        vm.removeImage = removeImage;
        vm.attachRecipeImages = attachRecipeImages;
        vm.removeIngredient = removeIngredient;
        vm.removeItem = removeItem;

        function removeItem(item) {
            vm.imagesNumber--;
            item.remove();
        }

        function removeIngredient(ingredients, index) {
            ingredients.splice(index, 1);
        }

        function attachRecipeImages() {
            $('#recipeImages').click();
        }

        function removeImage(image) {
            // to do imagesNumber--
            if (vm.imagesNumber == 1) {
                alert("there must be at least one image");
                return;
            }
            console.log(image);
            RecipeImageData.delete({ id: image.RecipeImageId }, function (data) {
                console.log(data);
                for (var i = 0 ; i < vm.recipe.RecipeImages.length; i++) {
                    if (vm.recipe.RecipeImages[i].RecipeImageId == data.RecipeImageId) {
                        vm.recipe.RecipeImages.splice(i, 1);
                    }
                }
                vm.imagesNumber--;
            })

        }

        function addIngredient() {
            var Ingredient = {};

            Ingredient.Name = vm.ingredientName;
            Ingredient.Quantity = vm.ingredientQuantity;

            vm.recipe.Ingredients.push(Ingredient);
            vm.ingredientName = "";
            vm.ingredientQuantity = "";
        }

        function recipeImageUploader(){
            return new FileUploader({
                url: "/api/upload/recipes/image/" + recipe.RecipeId + "/" + recipe.UserId,
                removeAfterUpload: false,
                autoUpload: false,
                queueLimit: 4,
                onAfterAddingFile: function (item) {
                    console.log(vm.imagesNumber);
                    if (vm.imagesNumber >= 4) {
                        item.remove();
                    }
                    vm.imagesNumber++;
                    
                },
                onSuccessItem: function (item, response, status, headers) {

                },
                onSuccess: function (response, status, headers) { },
                onCompleteAll: function () {
                    
                }
            });
        }

        function ok() {

            vm.recipeImageUploader.uploadAll();
            vm.recipe.PreparationTime = vm.hours * 60 + vm.minutes;

            RecipeData.update({ id: vm.recipe.RecipeId }, vm.recipe, function (data) {
                console.log(data);
                $uibModalInstance.close(data);
            },
            function () {
                $uibModalInstance.close();
            })
            
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }

    }
})()