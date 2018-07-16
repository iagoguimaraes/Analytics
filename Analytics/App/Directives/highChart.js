﻿angular.module('app').directive('highChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            type: '@',
            height: '@',
            series: '=',
            bgcolor: '@',
            gridLineColorX: '@',
            gridLineColorY: '@',
            colorCatX: '@',
            sizeCatX: '@',
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
            tooltipPointFormat: '@',
            tooltipShared: '@'
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('series', function () {
                Highcharts.chart(element[0], {
                    chart: {
                        type: scope.type,
                        height: scope.height,
                        backgroundColor: scope.bgcolor,
                    },
                    series: scope.series,
                    title: {
                        text: scope.titleText
                    },
                    xAxis: [
                        {
                            categories: scope.axisCategories,
                            gridLineColor: scope.gridLineColorX,
                        },
                        {
                            categories: scope.axis1Categories,
                            gridLineColor: scope.gridLineColorX,
                            opposite: true
                        }
                    ],
                    yAxis: [
                        {
                            gridLineColor: scope.gridLineColorY,

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
                        shared: scope.tooltipShared == 'false' ? false: true,
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

