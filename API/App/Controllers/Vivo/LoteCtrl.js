angular.module('app').controller('ctrl-vivo-lote', function ($scope, $http, $filter, dadosPagina) {
    dadosPagina.titulo = 'Lote';
    dadosPagina.descricao = 'Vivo'

    $scope.dashboard = {
        comparativo: {
            dia: 2,
            x: '%discado',
            y: '%promessa',
            z: 'total',
            indicador: '%discado'
        }
    };

    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/vivo/dashboard/lote",
            data: $scope.filtros,
        }).then(function success(r) {
            $scope.dashboard.status = r.status;
            $scope.dashboard.dados = r.data.Table;

            $scope.filtrarColumn();
            $scope.filtrarBubble();
        });
    }

    $scope.filtrarColumn = function () {
        $scope.dashboard.comparativo.column = $scope.dashboard.dados
            .filter(o => o.dia == $scope.dashboard.comparativo.dia)
            .map(o => ({
                name: o.data_inclusao,
                value: calcular($scope.dashboard.comparativo.indicador, o),
            }));

    };

    $scope.filtrarBubble = function () {
        $scope.dashboard.comparativo.bubble = $scope.dashboard.dados
            .filter(o => o.dia == $scope.dashboard.comparativo.dia)
            .map(o => ({
                name: o.data_inclusao,
                x: calcular($scope.dashboard.comparativo.x, o),
                y: calcular($scope.dashboard.comparativo.y, o),
                z: calcular($scope.dashboard.comparativo.z, o)
            }));
    };

    $scope.carregarDashboard();

});

function calcular(indicador, o) {
    switch (indicador) {
        case '%discado':
            return parseInt(o.discado * 100 / o.total);
            break;
        case '%contato':
            return parseInt(o.contato * 100 / o.total);
            break;
        case '%cpc':
            return parseInt(o.cpc * 100 / o.total);
            break;
        case '%cpca':
            return parseInt(o.cpca * 100 / o.total);
            break;
        case '%promessa':
            return parseInt(o.promessa * 100 / o.total);
            break;
        case 'conversao':
            return parseInt(o.promessa * 100 / o.cpca);
            break;
        case 'spin':
            return Math.round(o.ttdiscado / o.total * 1e1) / 1e1;
            break;
        default:
            return o[indicador];
    }
}