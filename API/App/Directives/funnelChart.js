angular.module('app').directive('funnelChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            dados: '=',
            height: '@',
            seriesName: '@',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {
                if (dados) {
                    Highcharts.chart(element[0], {

                        chart: {
                            type: 'funnel',
                            height: scope.height
                        },
                        title: {
                            text: ''
                        },
                        series: [{
                            name: scope.seriesName,
                            data: Object.keys(dados[0]).map(obj =>[obj, dados[0][obj]])
                        }],

                    });
                }
            });
        }
    }
});