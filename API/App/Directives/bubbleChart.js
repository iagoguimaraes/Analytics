angular.module('app').directive('bubbleChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            dados: '=',
            height: '@',
            tituloX: '=',
            tituloY: '=',
            tituloZ: '=',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {
                if (dados) {

                    Highcharts.chart(element[0], {
                        chart: {
                            type: 'bubble',
                            height: scope.height
                        },
                        title: {
                            text: ''
                        },
                        legend: {
                            enabled: false
                        },
                        xAxis: {
                            title: {
                                text: scope.tituloX
                            }
                        },
                        yAxis: {
                            title: {
                                text: scope.tituloY
                            }
                        },
                        series: [{
                            data: scope.dados

                        }],
                        plotOptions: {
                            series: {
                                dataLabels: {
                                    enabled: true,
                                    format: '{point.name}'
                                }
                            }
                        },
                        tooltip: {
                            useHTML: true,
                            headerFormat: '',
                            pointFormat:'<h4>{point.name}</h4>' + 
                                '<p><b>' + scope.tituloX + ':</b> {point.x}</p>' +
                                '<p><b>' + scope.tituloY + ':</b> {point.y}</p>' +
                                '<p><b>' + scope.tituloZ + ':</b> {point.z}</p>',
                            followPointer: true
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