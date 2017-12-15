angular.module('app').controller('ctrl-diariobordo', function ($scope, $http, $filter, dadosPagina) {
    dadosPagina.titulo = 'Diario de Bordo';
    dadosPagina.descricao = 'Digital'

    // filtros iniciais
    let ini = new Date();
    ini.setDate(ini.getDate() - 30);
    let fim = new Date();

    $scope.filtros = {
        dtini: $filter('date')(ini, "yyyy-MM-dd"),
        dtfim: $filter('date')(fim, "yyyy-MM-dd"),
        carteiras: null,
        empresas: null,
        ocorrencias: null,
        usuarios: null
    };

    $scope.opcoes = {};
    $scope.diario = {
        data: $filter('date')(new Date(), "yyyy-MM-dd")
    };

    $scope.dashboard = {};

    // carregar as opções do diario de bordo
    $http({
        method: 'POST',
        url: "/api/analytics/diariobordo/opcoes",
        data: $scope.filtros,
    }).then(function success(r) {
        $scope.opcoes.status = r.status;
        $scope.opcoes.empresas = r.data.Table;
        $scope.opcoes.carteiras = r.data.Table1;
        $scope.opcoes.ocorrencias = r.data.Table2;
        $scope.opcoes.usuarios = r.data.Table3;
    });

    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/analytics/diariobordo/consultar",
            data: $scope.filtros,
        }).then(function success(r) {
            $scope.dashboard.status = r.status;
            $scope.dashboard.dados = r.data.Table;
        });
    }

    $scope.inserirOcorrencia = function () {

        $http({
            method: 'POST',
            url: "/api/analytics/diariobordo/inserir",
            data: $scope.diario,
        }).then(function success(r) {
            $scope.diario = {
                data: $filter('date')(new Date(), "yyyy-MM-dd"),
                hora: ('0' + fim.getHours()).slice(-2) + ':' + ('0' + fim.getMinutes()).slice(-2)
            }

            $scope.carregarDashboard();
        });
    }

    $scope.carregarDashboard();

});