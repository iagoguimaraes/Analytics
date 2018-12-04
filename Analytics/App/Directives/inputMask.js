angular.module('app').directive('inputMask', function () {
    return {
        restrict: 'E',
        replace: true,    
        scope: {
            mask: '@',
            reverse: '@'
        },
        template: '<input type="text"/>',
        link: function (scope, element, attr, ctrl) {
            $(element).mask(scope.mask, {reverse: scope.reverse});
        }
    };
});