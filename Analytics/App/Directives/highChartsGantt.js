angular.module('app').directive('highChartsGantt', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            config: '=',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('config', function () {
                Highcharts.ganttChart(element[0], scope.config);
            });
        }
    }
});

