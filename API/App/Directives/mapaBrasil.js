angular.module('app').directive('mapaBrasil', function () {
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
                        type: "map",
                        theme: "light",
                        colorSteps: 10,
                        dataProvider: {
                            mapURL: "/App/Content/Libs/ammap/maps/svg/brazilLow.svg",
                            //getAreasFromMap: true,
                            zoomLevel: 0.9,
                            areas: dados
                        },
                        areasSettings: {
                            autoZoom: true,
                            balloonText: "[[title]]: <strong>[[value]]</strong>",
                        },
                        valueLegend: {
                            right: 10,                          
                        },
                        zoomControl: {
                            minZoomLevel: 0.9
                        },
                    });
                }               
            });
        }
    }
});