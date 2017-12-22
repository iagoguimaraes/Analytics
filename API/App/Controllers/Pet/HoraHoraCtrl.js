angular.module('app').controller('ctrl-pet-horahora', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'Hora Hora';
    dadosPagina.descricao = 'Health for Pet'

    $scope.filtros = {
        dtini: $filter('date')(new Date(), "yyyy-MM-dd"),
        dtfim: $filter('date')(new Date(), "yyyy-MM-dd"),
    };

    $scope.dashboard = {};

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/pet/dashboard/horahora",
            data: $scope.filtros,
        }).then(function success(r) {
            let data = r.data;
            $scope.dashboard.status = r.status;
            $scope.dashboard.resumo = data.Table[0];
            $scope.dashboard.carteiraativa = data.Table1[0];
            $scope.dashboard.horahora = data.Table2;
            $scope.dashboard.diagrama = data.Table3;
            $scope.dashboard.discador = data.Table4;

            console.log($scope.dashboard.horahora);
        });
    }

    $scope.carregarDashboard();

});