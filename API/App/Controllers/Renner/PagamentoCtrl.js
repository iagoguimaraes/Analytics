angular.module('app').controller('ctrl-renner-pagamento', function ($scope, $http, $filter, dadosPagina) {
    dadosPagina.titulo = 'Pagamento';
    dadosPagina.descricao = 'Renner'

    // filtros iniciais
    let ontem = new Date();
    ontem.setDate(ontem.getDate() - 15);

    $scope.filtros = {
        dtini: $filter('date')(ontem, "yyyy-MM-dd"),
        dtfim: $filter('date')(new Date(), "yyyy-MM-dd"),
        produtos: ''
    };
    $scope.dashFiltros = {};
    $scope.dashboard = {};

    // carregar os filtros
    $http({
        method: 'GET',
        url: "/api/renner/dashboard/filtros",
        data: $scope.filtros,
    }).then(function success(r) {
        let data = r.data;
        $scope.dashFiltros.status = r.status;
        $scope.dashFiltros.produtos = data.Table;
    });

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/renner/dashboard/pagamento",
            data: $scope.filtros,
        }).then(function success(r) {
            let data = r.data;
            $scope.dashboard.status = r.status;

            $scope.dashboard.dias = data.Table.map(o => o.data);
            $scope.dashboard.produtos = data.Table1.map(o => o.produto);

            $scope.dashboard.resumo = data.Table2[0];

            $scope.dashboard.produtoPgto = [{ name: 'Valor', data: data.Table3.map(o => ({ name: o.produto, y: o.vl_pagamento })) }];
            $scope.dashboard.produtoEftv = [{ name: 'Valor', data: data.Table4.map(o => o.efetividade) }];
            $scope.dashboard.diaPgto = [{ name: 'Valor', data: data.Table5.map(o => o.vl_pagamento) }];
            $scope.dashboard.diaProm = [
                { name: 'promessa', type: 'column', data: data.Table6.map(obj => obj.promessa) },
                { name: 'recebido', type: 'column', data: data.Table6.map(obj => obj.recebido) },
                { name: 'efetividade', type: 'spline', yAxis: 1, data: data.Table6.map(obj => obj.efetividade) },
            ];

        });
    }

    $scope.carregarDashboard();

});