angular.module('app').directive('highChartsGantt', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            config: '=',
        },
        template: '<div></div>',
        link: function (scope, element) {
            scope.$watch('config', function () {
                Highcharts.ganttChart(element[0], scope.config);
            });
        }
    }
});

Highcharts.setOptions({
    lang: {
        months: [
            'Janeiro', 'Fevereiro', 'Março', 'Abril',
            'Maio', 'Junho', 'Julho', 'Agosto',
            'Setembro', 'Outubro', 'Novembro', 'Dezembro'
        ],
        weekdays: [
            'Domingo', 'Segunda-Feira', 'Terça-Feira', 'Quarta-Feira',
            'Quinta-Feira', 'Sexta-Feira', 'Sabado'
        ],
        shortMonths: ['Jan','Fev','Mar','Abr','Mai','Jun','Jul','Ago','Set','Out','Nov','Dez'],
    }
});
