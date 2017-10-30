angular.module('app').controller('ctrl-mktzap-dashboard', function ($scope, $http, $filter, $interval, dadosPagina) {

    dadosPagina.titulo = 'Dashboard Mktzap';
    dadosPagina.descricao = '';

    // filtros iniciais
    let ontem = new Date();
    ontem.setDate(ontem.getDate()-1);

    $scope.filtros = {
        dtini: $filter('date')(ontem, "yyyy-MM-dd"),
        dtfim: $filter('date')(ontem, "yyyy-MM-dd"),
        campanhas: "",
        setores: ""
    };

    // atualização automática
    $scope.atualizar = {
        check: false,
        tempo: 60
    }
    $scope.Timer = null;

    // carrega os filtros e colocar no scope
    $scope.carregarFiltros = function () {
        $http({
            method: 'GET',
            url: "/api/mktzap/filtros",
        }).then(function success(r) {
            $scope.dadosFiltros = r;
        });
    }

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/mktzap/dashboard",
            data: $scope.filtros,
        }).then(function success(r) {            
            $scope.dashboard = r;
        });
    }

    // iniciar ou parar atualização automatica do dashbaord
    $scope.atualizarDash = function (v) {
        if (v) {
            $scope.Timer = $interval($scope.carregarDashboard, $scope.atualizar.tempo * 1000 * 60);
        }
        else {
            if (angular.isDefined($scope.Timer)) {
                $interval.cancel($scope.Timer);
            }
        }
    }

    $scope.carregarFiltros();
    $scope.carregarDashboard();

});