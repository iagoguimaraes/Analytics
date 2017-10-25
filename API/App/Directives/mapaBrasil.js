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

                AmCharts.makeChart(element[0], {
                    type: "map",
                    theme: "light",
                    colorSteps: 10,
                    dataProvider: {
                        mapURL: "/App/Content/Libs/ammap/maps/svg/brazilLow.svg",
                        getAreasFromMap: true,
                        zoomLevel: 0.9,
                        areas: [
                            { id: 'BR-AC', value: 500 },
                            { id: 'BR-AL', value: 500 },
                            { id: 'BR-AM', value: 500 },
                            { id: 'BR-AP', value: 500 },
                            { id: 'BR-BA', value: 500 },
                            { id: 'BR-CE', value: 500 },
                            { id: 'BR-DF', value: 500 },
                            { id: 'BR-ES', value: 500 },
                            { id: 'BR-GO', value: 500 },
                            { id: 'BR-MA', value: 500 },
                            { id: 'BR-MG', value: 500 },
                            { id: 'BR-MS', value: 500 },
                            { id: 'BR-MT', value: 500 },
                            { id: 'BR-PA', value: 500 },
                            { id: 'BR-PB', value: 500 },
                            { id: 'BR-PE', value: 500 },
                            { id: 'BR-PI', value: 500 },
                            { id: 'BR-PR', value: 500 },
                            { id: 'BR-RJ', value: 500 },
                            { id: 'BR-RN', value: 500 },
                            { id: 'BR-RO', value: 500 },
                            { id: 'BR-RR', value: 500 },
                            { id: 'BR-RS', value: 500 },
                            { id: 'BR-SC', value: 500 },
                            { id: 'BR-SE', value: 500 },
                            { id: 'BR-SP', value: 500 },
                            { id: 'BR-TO', value: 500 },
                        ]
                    },
                    areasSettings: {
                        autoZoom: true,
                        balloonText: "[[title]]: <strong>[[value]]</strong>"
                    },
                    valueLegend: {
                        right: 10,
                        minValue: "Mínimo",
                        maxValue: "Máximo"
                    },
                    zoomControl: {
                        minZoomLevel: 0.9
                    },
                });

            });
        }
    }
});