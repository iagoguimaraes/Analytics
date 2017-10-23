angular.module('app').controller('ctrl-tim-horahora', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'DASHBOARD TIM';
    dadosPagina.descricao = 'Hora Hora'


    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        dadosPagina.loading = true;
        $http({
            method: 'POST',
            url: "/api/tim/dashboard/horahora",
            data: { dtini: '2017-10-23', dtfim: '2017-10-23' },
        }).then(function success(r) {
            //console.log(r.data);
            $scope.dashboard = r;

            dadosPagina.loading = false;
        }, function error(r) {
            alert(r.data.Message);
        });
    }


    $scope.carregarDashboard();

});