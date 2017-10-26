angular.module('app').directive('sankeyChart', function () {
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

                Highcharts.chart(element[0], {
                    chart: {
                        height: scope.height,
                    },
                    series: [{
                        keys: ['from', 'to', 'weight'],
                        data: dados.map(obj =>[obj['de'], obj['para'], obj['qtd']]),
                        type: 'sankey',
                        name: scope.seriesName
                    }]

                });

            });
        }
    }
});