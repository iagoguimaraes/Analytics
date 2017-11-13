angular.module('app').controller('ctrl-mktzap-dashboard', function ($scope, $http, $filter, $interval, dadosPagina) {

    dadosPagina.titulo = 'Dashboard Mktzap';
    dadosPagina.descricao = '';

    $scope.filtros = {
        fDtini: $filter('date')(new Date(), "yyyy-MM-dd"),
        fDtfim: $filter('date')(new Date(), "yyyy-MM-dd"),
        eDtini: "",
        eDtfim: "",
        campanhas: "",
        setores: ""
    };

    $scope.mapa = {
        indicador: 'atendimento'
    };
    $scope.grafico = {
        eixo: 'dataentrada',
        indicador: 'atendimento'
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
            $scope.carregarMapa();
            $scope.carregarGrafico();
        });
    }

    // carrega o mapa de acordo com o indicador escolhido
    $scope.carregarMapa = function () {
        let dados = $scope.dashboard.data.Table5;
        switch ($scope.mapa.indicador) {
            case '%finalizado':
                $scope.mapa.dados = dados.map(obj => ({ id: 'BR-' + obj.uf, value: (obj.finalizado * 100 / obj.atendimento).toFixed(1) }));
                break;
            case '%interacao':
                $scope.mapa.dados = dados.map(obj => ({ id: 'BR-' + obj.uf, value: (obj.interacao * 100 / obj.finalizado).toFixed(1) }));
                break;
            case '%cpc':
                $scope.mapa.dados = dados.map(obj => ({ id: 'BR-' + obj.uf, value: (obj.cpc * 100 / obj.interacao).toFixed(1) }));
                break;
            case '%negociado':
                $scope.mapa.dados = dados.map(obj => ({ id: 'BR-' + obj.uf, value: (obj.negociacao * 100 / obj.cpca).toFixed(1) }));
                break;
            default:
                $scope.mapa.dados = dados.map(obj => ({ id: 'BR-' + obj.uf, value: obj[$scope.mapa.indicador] }));
        }
    }

    $scope.carregarGrafico = function () {
        let dados;

        if($scope.grafico.eixo == 'dataentrada')
            dados = $scope.dashboard.data.Table6;
        else if ($scope.grafico.eixo == 'datafinalizado')
            dados = $scope.dashboard.data.Table7;

        switch ($scope.grafico.indicador) {
            case '%finalizado':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: (obj.finalizado * 100 / obj.atendimento).toFixed(1) }));
                break;
            case '%interacao':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: (obj.interacao * 100 / obj.finalizado).toFixed(1) }));
                break;
            case '%cpc':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: (obj.cpc * 100 / obj.interacao).toFixed(1) }));
                break;
            case '%negociado':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: (obj.negociacao * 100 / obj.cpca).toFixed(1) }));
                break;
            default:
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: obj[$scope.grafico.indicador] }));
        }
    }


    $scope.carregarFiltros();
    $scope.carregarDashboard();

});