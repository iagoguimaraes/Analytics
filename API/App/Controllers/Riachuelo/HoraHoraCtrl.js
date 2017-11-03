angular.module('app').controller('ctrl-riachuelo-horahora', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'Hora Hora';
    dadosPagina.descricao = 'Riachuelo'

    $scope.filtros = {
        dtini: $filter('date')(new Date(), "yyyy-MM-dd"),
        dtfim: $filter('date')(new Date(), "yyyy-MM-dd"),
        carteiras: ''
    };
    $scope.dashFiltros = {};
    $scope.dashboard = {};

    // carregar os filtros
    $http({
        method: 'GET',
        url: "/api/riachuelo/dashboard/filtros",
        data: $scope.filtros,
    }).then(function success(r) {
        let data = r.data;
        $scope.dashFiltros.status = r.status;
        $scope.dashFiltros.carteiras = data.Table;
    });

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/riachuelo/dashboard/horahora",
            data: $scope.filtros,
        }).then(function success(r) {
            let data = r.data;
            $scope.dashboard.status = r.status;
            $scope.dashboard.resumo = data.Table[0];
            $scope.dashboard.carteiraativa = data.Table1[0];
            $scope.dashboard.carteira = data.Table2;
            $scope.dashboard.horahora = data.Table3;
            $scope.dashboard.diagrama = data.Table4;
            $scope.dashboard.discador = data.Table5;
        });
    }

    $scope.carregarDashboard();

});