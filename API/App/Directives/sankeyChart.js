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
                if (dados) {
                    Highcharts.chart(element[0], {
                        chart: {
                            height: scope.height,
                        },
                        title: {
                            text: ''
                        },
                        series: [{
                            keys: ['from', 'to', 'weight'],
                            data: dados.map(obj =>[obj['de'], obj['para'], obj['qtd']]),
                            type: 'sankey',
                            name: scope.seriesName
                        }],
                        tooltip: {
                            pointFormatter: function () {
                                return this.fromNode.name + ' → ' + this.toNode.name + ' (' + (this.weight * 100 / this.fromNode.sum).toFixed(1) + '%)'
                            }
                        },
                        credits: {
                            enabled: false
                        },
                    });
                }
            });
        }
    }
});