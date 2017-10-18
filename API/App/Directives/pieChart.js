angular.module('app').directive('pieChart', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            titulo: '@',
            subtitulo: '@',
            dados: '=',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {
                Highcharts.chart(element[0], {
                    chart: {
                        type: 'pie'
                    },
                    title: {
                        text: scope.titulo
                    },
                    subtitle: {
                        text: scope.subtitulo
                    },
                    series: [{
                        name: scope.seriesName,
                        data: dados.map(obj => ({ 'name': obj[Object.keys(obj)[0]], 'y': obj[Object.keys(obj)[1]] }))
                    }],
                    tooltip: {
                        pointFormat: '{point.y} (<b>{point.percentage:.1f}%</b>)'
                    },
                });
            });
        }
    }
});