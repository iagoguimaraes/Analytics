angular.module('app').controller('MktzapDashboardCtrl', function ($scope, $http) {

    $scope.filtros = { dtini: "", dtfim: "", campanhas: "", setores: "" };   

    // carrega os filtros e colocar no scope
    $http({
        method: 'GET',
        url: "/api/mktzap/filtros",
    }).then(function success(r) {
        $scope.dadosFiltros = r;
    }, function error(r) {
        alert(r.data.Message);
    });

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/mktzap/dashboard",
            data: $scope.filtros,
        }).then(function success(r) {
            $scope.dashboard = r;
        }, function error(r) {
            alert(r.data.Message);
        });
    }

});