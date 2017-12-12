angular.module('app').controller('ctrl-riachuelo-efetividade', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'Efetividade';
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
            url: "/api/riachuelo/dashboard/efetividade",
            data: $scope.filtros,
        }).then(function success(r) {
            let data = r.data;
            $scope.dashboard.status = r.status;

            $scope.dashboard.promessaPagaCarteira = data.Table.map(obj => ({carteira: obj.carteira, promessaPaga: obj.promessaPaga}));
            $scope.dashboard.efetividadeCarteira = data.Table.map(obj => ({carteira: obj.carteira, efetividade: (obj.promessaPaga*100/obj.promessa).toFixed(1)/1 }));

            $scope.dashboard.promessaPagaDia = data.Table1.map(obj => ({ data: obj.data, promessaPaga: obj.promessaPaga }));
            $scope.dashboard.efetividadeDia = data.Table1.map(obj => ({ data: obj.data, efetividade: (obj.promessaPaga*100/obj.promessa).toFixed(1)/1 }));

            $scope.dashboard.pagamentoLoteCarteira = data.Table2.map(obj => ({ carteira: obj.carteira, promessaPaga: obj.pago }));
            $scope.dashboard.efetividadeLoteCarteira = data.Table2.map(obj => ({ carteira: obj.carteira, efetividade: (obj.pago * 100 / obj.inclusao).toFixed(1) / 1 }));

            $scope.dashboard.pagamentoLoteDia = data.Table3.map(obj => ({ data: obj.data, promessaPaga: obj.pago }));
            $scope.dashboard.efetividadeLoteDia = data.Table3.map(obj => ({ data: obj.data, efetividade: (obj.pago * 100 / obj.inclusao).toFixed(1) / 1 }));

        });
    }

    $scope.carregarDashboard();

});