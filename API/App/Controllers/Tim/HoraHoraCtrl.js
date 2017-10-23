angular.module('app').controller('ctrl-tim-horahora', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'DASHBOARD TIM';
    dadosPagina.descricao = 'Hora Hora'

    $scope.filtros = {
        dtini: $filter('date')(new Date(), "yyyy-MM-dd"),
        dtfim: $filter('date')(new Date(), "yyyy-MM-dd"),
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

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        dadosPagina.loading = true;
        $http({
            method: 'POST',
            url: "/api/tim/dashboard/horahora",
            data: $scope.filtros,
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