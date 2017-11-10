angular.module('app').directive('barChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            dados: '=',
            height: '@',
            yAxisTitle: '@',
            seriesName: '@',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {
                if (dados) {
                    Highcharts.chart(element[0], {
                        chart: {
                            type: 'bar',
                            height: scope.height
                        },
                        title: {
                            text: ''
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