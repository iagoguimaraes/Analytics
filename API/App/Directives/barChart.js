angular.module('app').directive('barChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            dados: '=',
            titulo: '@',
            subtitulo: '@',
            height: '@',
            yAxisTitle: '@',
            seriesName: '@',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {
                Highcharts.chart(element[0], {
                    chart: {
                        type: 'bar'
                    },
                    title: {
                        text: scope.titulo
                    },
                    subtitle: {
                        text: scope.subtitulo
                    },
                    xAxis: {
                        categories: dados.map(obj => obj[Object.keys(obj)[0]]),
                        crosshair: true
                    },
                    yAxis: {
                        title: {
                            text: scope.yAxisTitle
                        }
                    },
                    series: [{
                        name: scope.seriesName,
                        data: dados.map(obj => obj[Object.keys(obj)[1]])
                    }],
                    plotOptions: {
                        bar: {
                            dataLabels: {
                                enabled: true,
                            }
                        }
                    }

                });
            });
        }
    }
});