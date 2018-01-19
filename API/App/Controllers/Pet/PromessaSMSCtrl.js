angular.module('app').controller('ctrl-pet-promessasms', function ($scope, $http, $filter, dadosPagina) {
    dadosPagina.titulo = 'Promessa SMS';
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
            url: "/api/pet/dashboard/promessasms",
            data: $scope.filtros,
        }).then(function success(r) {
            let data = r.data;
            $scope.dashboard.status = r.status;
            $scope.dashboard.promessa = data.Table;
        });
    }

    $scope.checkSMS = function (chamada) {
        $http({
            method: 'POST',
            url: "/api/pet/dashboard/checksms",
            data: {
                id_chamada: chamada.id_chamada,
                sms: chamada.sms
            },
        });
    }

    $scope.carregarDashboard();

});