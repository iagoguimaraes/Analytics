angular.module('app').controller('ctrl-riachuelo-pagamento', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'Pagamento';
    dadosPagina.descricao = 'Riachuelo'

    // filtros iniciais
    let ontem = new Date();
    ontem.setDate(ontem.getDate() - 7);

    $scope.filtros = {
        dtini: $filter('date')(ontem, "yyyy-MM-dd"),
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
            url: "/api/riachuelo/dashboard/pagamento",
            data: $scope.filtros,
        }).then(function success(r) {
            let data = r.data;
            $scope.dashboard.status = r.status;

            $scope.dashboard.resumo = data.Table[0];
            $scope.dashboard.qtDia = data.Table1;
            $scope.dashboard.vlDia = data.Table2;
            $scope.dashboard.qtCarteira = data.Table3;
            $scope.dashboard.vlCarteira = data.Table4;

        });
    }

    $scope.carregarDashboard();

});