angular.module('app').directive('lineAmChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            dados: '=',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {
                if (dados) {
                    AmCharts.makeChart(element[0], {
                        type: "serial",
                        theme: "light",
                        dataProvider: dados,
                        categoryField: "hora",
                        graphs: [
                            {
                                valueField: "promessa",
                                bullet: "round",
                                dashLength: 2,
                                bulletSize: 15,
                                bulletColor: "#8d83c8",
                                lineColor: "#5bb5ea",
                            }
                        ],
                        chartCursor: {
                            fullWidth: true,
                            cursorColor: "#FFFFFF",
                            categoryBalloonColor: "#8d83c8",
                            balloonPointerOrientation: "vertical"
                        },
                    });
                }
             
            });
        }
    }
});