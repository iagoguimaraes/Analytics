angular.module('app').controller('ctrl-vivo-lote', function ($scope, $http, $filter, dadosPagina) {
    dadosPagina.titulo = 'Lote';
    dadosPagina.descricao = 'Vivo'

    $scope.dashboard = {
        filtro: {
            dia: 10
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

            $scope.filtrarDados();
        });
    }

    $scope.filtrarDados = function () {
        if ($scope.dashboard.filtro.dia)
            $scope.dashboard.lote = $scope.dashboard.dados.filter(o => o.dia = $scope.dashboard.filtro.dia);
    };

    $scope.carregarDashboard();

});