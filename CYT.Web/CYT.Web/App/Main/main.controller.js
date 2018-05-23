(function () {
    'use strict'

    angular
        .module("app.main")
        //.filter('startFrom', function () {
        //    return function (input, start) {
        //        if (!input || !input.length) { return; }
        //        start += start;
        //        return input.slice(start);
        //    }
        //})
        .controller("MainController", MainController);

    MainController.$inject = ["RecipeData"];

    function MainController(RecipeData) {
        var vm = this;
        vm.test = "test";
        RecipeData.query(function(data){
            //console.log(data); 
            vm.recipes = data;
            vm.recipeDifficulties = ["Easy", "Medium", "Advanced"];
            vm.carouselRecipes = [];
            vm.carouselRecipes.push(data[data.length - 1]);
            vm.carouselRecipes.push(data[data.length - 2]);
            vm.carouselRecipes.push(data[data.length - 3]);
            vm.ratings = [];
            for (var i = 0; i < vm.carouselRecipes.length; i++) {
                var total = 0;
                for (var j = 0; j < vm.carouselRecipes[i].RecipeVotes.length; j++) {
                    total += vm.carouselRecipes[i].RecipeVotes[j].VoteValue;
                }
                if(total!=0)
                    total /= vm.carouselRecipes[i].RecipeVotes.length;
                vm.ratings.push(total);
            }
            //Pagination
            //vm.currentPage = 0;
            //vm.pageSize = 3;
            //vm.numberOfPages = function () {
            //    return Math.ceil(vm.data.length / vm.pageSize);
            //}
        })
        vm.fruits = ["Apple", "Banana", "Peach", "Orange"];
        vm.proba;
    }
    
})()