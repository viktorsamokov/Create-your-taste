(function () {
    'use strict'

    angular
        .module("app.recipe")
        .controller("RecipeController", RecipeController);

    RecipeController.$inject = ['$stateParams', 'RecipeData', '$sce','UserData','RecipeVoteData'];

    function RecipeController($stateParams, RecipeData, $sce,UserData, RecipeVoteData) {
        var vm = this;
        vm.hour;
        vm.minutes;
        vm.difficulty;
        vm.interval = 2000;
        vm.youtubeUrl = "";
        vm.similarRecipes = RecipeData.getSimilarRecipes({ recipeId: $stateParams.id }, function (data) {
            //console.log(data);
        })
        vm.gluten = "Yes";
        vm.isLogged=false;
        vm.user = UserData.isLoggedIn(userLogged);

        vm.recipe = RecipeData.getRecipe({ recipeId: $stateParams.id }, callback)
        if(!vm.recipe.glutenFree)
        {
            vm.gluten="No";
        }
        vm.vote = {};
        
        vm.voteForRecipe=voteForRecipe;
        vm.favoriteRecipe = favoriteRecipe;
        vm.favorited = false;
        
        function voteForRecipe(vote) {
            console.log(vote)
            vm.value = vote.VoteValue;
            if(vote.RecipeVoteId>=0)
            {
                RecipeVoteData.update({ id: vote.RecipeVoteId }, vote, function (data) {
                    vm.vote = data;
                 
                });
            }
            else
            {
                var x = {};
                x.VoteValue = vm.value;
                x.UserId = vm.user.UserId;
                x.RecipeId = vm.recipe.RecipeId;
                console.log(x);
                RecipeVoteData.save(x,function(data){
                    vm.vote=data;
                });
            }
        }
        function favoriteRecipe() {
            console.log("ovde");
            console.log(vm.recipe.RecipeId);
            console.log(vm.user.UserId);
            UserData.favoriteRecipe({ userId: vm.user.UserId, recipeId: vm.recipe.RecipeId }, function (data) {
                console.log(data);
            });
            vm.favorited = true;
        }
        function userLogged(data)
        {
            if(data[0]=="False")
                vm.isLogged=false;
            else
               {
                vm.isLogged=true;
                vm.user = data[0];
                UserData.getFavoriteRecipes({ userId: vm.user.UserId }, function (data) {
                    for(var x=0;x<data.length;x++)
                    {
                        if (data[x].RecipeId == vm.recipe.RecipeId) {
                            vm.favorited = true;
                        }
                    }
                });
                }
                
        }
        function callback(data) {
            if (!data)
                $state.go("main");
            console.log(vm.user);
            vm.recipe = data[0];
            vm.vote = RecipeVoteData.userVote({ recipeId: vm.recipe.RecipeId, userId: vm.user.UserId }, function (data) {
                vm.vote = data[0];
                console.log(vm.vote.VoteValue);
            }, function () { console.log("failed") });

            vm.youtubeUrl = $sce.trustAsResourceUrl(vm.recipe.VideoUrl.replace("watch?v=", "v/"));
            if (vm.recipe.Difficulty == 0) {
                vm.difficulty = "Easy"
            }
            else if (vm.recipe.Difficulty == 1) {
                vm.difficulty = "Medium"
            }
            else if (vm.recipe.Difficulty == 2) {
                vm.difficulty = "Advanced"
            }
            if (vm.recipe.PreparationTime > 60) {
                vm.hour = Math.floor(vm.recipe.PreparationTime / 60)
                vm.minutes = vm.recipe.PreparationTime % 60;
            }
            console.log(vm.recipe);
        };
    }
})()