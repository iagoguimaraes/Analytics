angular.module('app').controller('ctrl-diariobordo', function ($scope, $http, $filter, dadosPagina) {
    dadosPagina.titulo = 'Diario de Bordo';
    dadosPagina.descricao = 'Digital'

    // filtros iniciais
    let ini = new Date();
    ini.setDate(ini.getDate() - 30);
    let fim = new Date();

    // filtros para pesquisa de diario de bordo
    $scope.filtros = {
        dtini: $filter('date')(ini, "yyyy-MM-dd"),
        dtfim: $filter('date')(fim, "yyyy-MM-dd"),
        carteiras: null,
        empresas: null,
        ocorrencias: null,
        usuarios: null
    };

    // possiveis opcoes de escolha do formulario
    $scope.opcoes = {};

    // dados para inserir uma nova ocorrencia
    $scope.diario = {
        data: $filter('date')(new Date(), "yyyy-MM-dd")
    };

    // dados para editar uma ocorrencia
    $scope.editdiario = {       
    };

    // lista de ocorrencias
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

    // carregar a lista de ocorrencias
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

    // inserir nova ocorrencia
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

    // popular pop up de editar ocorrencia
    $scope.popularEdit = function (r) {
        $scope.editdiario.id = r.id_diario_bordo;
        $scope.editdiario.data = r.data;
        $scope.editdiario.hora = r.hora;
        $scope.editdiario.empresa = r.id_empresa;
        $scope.editdiario.carteira = r.id_carteira;
        $scope.editdiario.ocorrencia = r.id_ocorrencia;
        $scope.editdiario.descricao = r.descricao;
    }

    $scope.editarOcorrencia = function () {
        $scope.editdiario.empresa = $scope.editdiario.empresa || 0;
        $scope.editdiario.carteira = $scope.editdiario.carteira || 0;
        $scope.editdiario.ocorrencia = $scope.editdiario.ocorrencia || 0;

        $http({
            method: 'POST',
            url: "/api/analytics/diariobordo/editar",
            data: $scope.editdiario,
        }).then(function success(r) {
            $scope.carregarDashboard();
        });
    }

    $scope.removerOcorrencia = function () {
        $http({
            method: 'POST',
            url: "/api/analytics/diariobordo/remover",
            data: $scope.editdiario,
        }).then(function success(r) {
            $scope.carregarDashboard();
        });
    }

    $scope.carregarDashboard();

});