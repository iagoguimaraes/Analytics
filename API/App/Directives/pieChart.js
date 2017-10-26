angular.module('app').directive('pieChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            dados: '=',
            height: '@',
            innerSize: '@',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {
                if (dados) {
                    Highcharts.chart(element[0], {
                        title: {
                            text: ''
                        },
                        chart: {
                            type: 'pie',
                            height: scope.height
                        },
                        series: [{
                            name: scope.seriesName,
                            data: dados.map(obj => ({ 'name': obj[Object.keys(obj)[0]], 'y': obj[Object.keys(obj)[1]] })),
                            innerSize: scope.innerSize,
                        }],
                        tooltip: {
                            pointFormat: '{point.y} (<b>{point.percentage:.1f}%</b>)'
                        },

                    });
                }                
            });
        }
    }
});