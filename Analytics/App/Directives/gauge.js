angular.module('app').directive('gauge', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            config: '=',
        },
        template: '<canvas></canvas>',
        link: function (scope, element) {
            scope.$watch('config', function () {
                if (scope.config) {
                    let gauge = new Gauge(element[0]).setOptions(scope.config);
                    gauge.minValue = scope.config.minValue;
                    gauge.maxValue = scope.config.maxValue;
                    gauge.set(scope.config.value);
                }                              
            });
        }
    }
});

