angular.module('app').directive('mapaBrasil', function () {
    return {
        restrict: 'E',
        replace: true,
        require: '^?ngModel',
        scope: {
            dados: '=',
        },
        template: '<div></div>',
        link: function (scope, element, attrs, ngModelCtrl) {
            scope.$watch('dados', function (dados) {
                if (dados) {
                    AmCharts.makeChart(element[0], {
                        type: "map",
                        theme: "light",
                        colorSteps: 10,
                        dataProvider: {
                            mapURL: "/Content/Libs/ammap/maps/svg/brazilLow.svg",
                            //getAreasFromMap: true,
                            zoomLevel: 0.9,
                            areas: dados
                        },
                        areasSettings: {
                            autoZoom: false,
                            selectable: true,
                            balloonText: "[[title]]: <strong>[[value]] </strong>", //[[percent]]%
                        },
                        valueLegend: {
                            right: 10,                          
                        },
                        zoomControl: {
                            minZoomLevel: 0.9
                        },
                    }).addListener("clickMapObject", function (event) {
                        //document.getElementById("info").innerHTML = 'Clicked ID: ' + event.mapObject.id + ' (' + event.mapObject.title + ')';
                        ngModelCtrl.$setViewValue(event.mapObject.id);

                    });                  

                }               
            });

        }
    }
});