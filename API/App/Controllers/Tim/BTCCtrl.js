angular.module('app').controller('ctrl-tim-btc', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'Best Time to Call';
    dadosPagina.descricao = 'Tim'

    $scope.dashboard = {};
    $scope.indicador_mapa = 'hitrate'

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
        }, function error(r) {
            alert(r.data.Message);
        });
    }


    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDados = function () {
        dadosPagina.loading = true;
        $http({
            method: 'POST',
            url: "/api/tim/dashboard/btc",
            data: $scope.filtros,
        }).then(function success(r) {
            $scope.dashboard.dados = r.data;

            $scope.carregarMapa();

            dadosPagina.loading = false;
        }, function error(r) {
            alert(r.data.Message);
        });
    }

    // carrega o mapa de acordo com o indicador escolhido
    $scope.carregarMapa = function () {
        let dados = $scope.dashboard.dados.Table;        
        switch ($scope.indicador_mapa) {
            case 'hitrate':
                $scope.dashboard.mapa = dados.map(obj => ({ id: 'BR-' + obj.uf, value: (obj.contato * 100 / obj.discado).toFixed(1) }));
                break;
            case 'txloc':
                $scope.dashboard.mapa = dados.map(obj => ({ id: 'BR-' + obj.uf, value: (obj.cpc * 100 / obj.contato).toFixed(1) }));
                break;
            case 'txapv':
                $scope.dashboard.mapa = dados.map(obj => ({ id: 'BR-' + obj.uf, value: (obj.cpca * 100 / obj.cpc).toFixed(1) }));
                break;
            case 'conversao':
                $scope.dashboard.mapa = dados.map(obj => ({ id: 'BR-' + obj.uf, value: (obj.promessa * 100 / obj.cpca).toFixed(1) }));
                break;
            default:
                $scope.dashboard.mapa = dados.map(obj => ({ id: 'BR-' + obj.uf, value: obj[$scope.indicador_mapa] }));
        }
    }

    $scope.carregarFiltros();
    $scope.carregarDados();

});