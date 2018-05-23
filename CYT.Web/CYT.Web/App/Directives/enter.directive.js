(function () {
    'use strict';

    angular
    .module('app.widgets')
    .directive('ngEnter', ngEnter);

    ngEnter.$inject = [];

    function ngEnter() {
        var directive = {
            link: link,
            restrict: 'A'
        };

        return directive;

        function link(scope, element, attrs) {
            
            element.bind("keydown", function (event) {
                console.log("in")
                if (event.which === 13) {

                    event.preventDefault();
                    event.stopPropagation();

                    scope.$apply(function () {
                        scope.$eval(attrs.ngEnter);
                    });


                }
            });
        }
    }

})();