angular.module('app').controller('ctrl-tim-horahora', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'Hora Hora';
    dadosPagina.descricao = 'Tim'

    $scope.filtros = {
        dtini: $filter('date')(new Date(), "yyyy-MM-dd"),
        dtfim: $filter('date')(new Date(), "yyyy-MM-dd"),
        campanhas: null,
    };

    // atualização automática
    $scope.atualizar = {
        check: false,
        tempo: 60
    }
    $scope.Timer = null;

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

    // carrega os filtros e colocar no scope
    $scope.carregarFiltros = function () {
        $http({
            method: 'GET',
            url: "/api/tim/dashboard/filtros",
        }).then(function success(r) {
            $scope.dashboardFiltros = r;
        });
    }


    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/tim/dashboard/horahora",
            data: $scope.filtros,
        }).then(function success(r) {
            $scope.dashboard = r;        
        });
    }

    $scope.carregarFiltros();
    $scope.carregarDashboard();

});