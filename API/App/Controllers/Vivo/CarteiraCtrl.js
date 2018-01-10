angular.module('app').controller('ctrl-vivo-carteira', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'Carteira';
    dadosPagina.descricao = 'Vivo'

    // filtros iniciais
    let ontem = new Date();
    ontem.setDate(ontem.getDate() - 15);

    $scope.filtros = {
        dtini: $filter('date')(ontem, "yyyy-MM-dd"),
        dtfim: $filter('date')(new Date(), "yyyy-MM-dd"),
        segmentacoes: ''
    };
    $scope.dashFiltros = {};
    $scope.dashboard = {};
    $scope.grafico = {
        indicador: 'ativo'
    };

    // carregar os filtros
    $http({
        method: 'GET',
        url: "/api/vivo/dashboard/filtros",
        data: $scope.filtros,
    }).then(function success(r) {
        let data = r.data;
        $scope.dashFiltros.status = r.status;
        $scope.dashFiltros.segmentacoes = data.Table1;
    });

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/vivo/dashboard/carteira",
            data: $scope.filtros,
        }).then(function success(r) {
            $scope.dashboard.status = r.status;

            $scope.dashboard.resumo = r.data.Table[0];
            $scope.dashboard.carteira = r.data.Table1;
            $scope.dashboard.dia = r.data.Table2;

            $scope.carregarGrafico();
        });
    }


    // carrega o mapa de acordo com o indicador escolhido
    $scope.carregarGrafico = function () {
        let dados = $scope.dashboard.dia;
        let indicador = $scope.grafico.indicador;

        $scope.dashboard.graficoQtd = dados.map(obj => ({ data: obj['data'], value: obj[indicador] }));
        $scope.dashboard.graficoVlr = dados.map(obj => ({ data: obj['data'], value: obj[indicador + 'Vlr'] }));
        $scope.dashboard.graficoAgn = dados.map(obj => ({ data: obj['data'], value: obj[indicador + 'Agn'] }));
    }


    $scope.carregarDashboard();

});