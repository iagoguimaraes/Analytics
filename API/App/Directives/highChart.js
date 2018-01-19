angular.module('app').directive('highChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            type: '@',
            height: '@',
            series: '=',
            titleText: '@',
            axisCategories: '=',
            yAxisTitle: '@',
            yAxisMin: '@',
            yAxisMax: '@',
            yAxis1Title: '@',
            yAxis1Min: '@',
            yAxis1Max: '@',
            plotOptionsColumnDataLabel: '@',
            plotOptionsColumnStacking: '@',
            plotOptionsSplineDataLabel: '@',
            plotOptionsBarDataLabel: '@',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('series', function () {
                Highcharts.chart(element[0], {
                    chart: {
                        type: scope.type,
                        height: scope.height
                    },
                    series: scope.series,
                    title: {
                        text: scope.titleText
                    },
                    xAxis: {
                        categories: scope.axisCategories,
                    },
                    yAxis: [
                        {
                            title: {
                                text: scope.yAxisTitle
                            },
                            min: scope.yAxisMin,
                            max: scope.yAxisMax,
                        },
                        {
                            title: {
                                text: scope.yAxis1Title
                            },
                            min: scope.yAxis1Min,
                            max: scope.yAxis1Max,
                            opposite: true
                        }
                    ],
                    plotOptions: {
                        column: {
                            dataLabels: {
                                enabled: scope.plotOptionsColumnDataLabel
                            },
                            stacking: scope.plotOptionsColumnStacking
                        },
                        line: {
                            dataLabels: {
                                enabled: scope.plotOptionsLineDataLabel
                            }
                        },
                        spline: {
                            dataLabels: {
                                enabled: scope.plotOptionsSplineDataLabel
                            }
                        },
                        bar: {
                            dataLabels: {
                                enabled: scope.plotOptionsBarDataLabel
                            }
                        }
                    },
                    tooltip: {
                        shared: true
                    },
                    credits: {
                        enabled: false
                    },

                });

            });
        }
    }
});