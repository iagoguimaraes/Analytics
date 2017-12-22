﻿angular.module('app').controller('ctrl-pet-producao', function ($scope, $http, $filter, dadosPagina) {
    dadosPagina.titulo = 'Produção';
    dadosPagina.descricao = 'Health for Pet'

    // filtros iniciais
    let ontem = new Date();
    ontem.setDate(ontem.getDate() - 7);

    $scope.filtros = {
        dtini: $filter('date')(ontem, "yyyy-MM-dd"),
        dtfim: $filter('date')(new Date(), "yyyy-MM-dd"),
    };

    $scope.dashboard = {};
    $scope.grafico = {indicador: 'hitrate'};

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/pet/dashboard/producao",
            data: $scope.filtros,
        }).then(function success(r) {
            let data = r.data;
            $scope.dashboard.status = r.status;
            $scope.dashboard.resumo = data.Table[0];
            $scope.dashboard.dia = data.Table1;

            $scope.carregarGrafico();

        });
    }

    // carrega o mapa de acordo com o indicador escolhido
    $scope.carregarGrafico = function () {
        let dados = $scope.dashboard.dia;
        switch ($scope.grafico.indicador) {
            case 'hitrate':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: (obj.contato * 100 / obj.discado).toFixed(1) }));
                break;
            case 'txloc':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: (obj.cpc * 100 / obj.contato).toFixed(1) }));
                break;
            case 'txapv':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: (obj.cpca * 100 / obj.cpc).toFixed(1) }));
                break;
            case 'conversao':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: (obj.promessa * 100 / obj.cpca).toFixed(1) }));
                break;
            default:
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.data, value: obj[$scope.grafico.indicador] }));
        }
    }

    $scope.carregarDashboard();

});