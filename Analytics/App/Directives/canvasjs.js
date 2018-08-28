angular.module('app').directive('canvasjs', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            config: '=',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('config', function () {
                let chart = new CanvasJS.Chart(element[0], scope.config);
                chart.render();               
            });
        }
    }
});





