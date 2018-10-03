angular.module('app').directive('highCharts', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            config: '=',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('config', function () {
                Highcharts.chart(element[0], scope.config);
            });
        }
    }
});

