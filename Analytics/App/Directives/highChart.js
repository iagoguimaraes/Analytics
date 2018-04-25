﻿angular.module('app').directive('highChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            type: '@',
            height: '@',
            series: '=',
            titleText: '@',
            axisCategories: '=',
            axis1Categories: '=',
            yAxisTitle: '@',
            yAxisMin: '@',
            yAxisMax: '@',
            yAxis1Title: '@',
            yAxis1Min: '@',
            yAxis1Max: '@',
            plotOptionsColumnDataLabel: '@',
            plotOptionsColumnStacking: '@',
            plotOptionsLineDataLabel: '@',
            plotOptionsSplineDataLabel: '@',
            plotOptionsBarDataLabel: '@',
            tooltipPointFormat: '@'
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
                    xAxis: [
                        {
                            categories: scope.axisCategories,
                        },
                        {
                            categories: scope.axis1Categories,
                            opposite: true
                        }
                    ],
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
                        shared: true,
                        pointFormat: scope.tooltipPointFormat || '<span style="color:{point.color}">\u25CF</span> {series.name}: <b>{point.y}</b><br/>'
                    },
                    credits: {
                        enabled: false
                    },

                });

            });
        }
    }
});

