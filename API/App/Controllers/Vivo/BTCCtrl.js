angular.module('app').controller('ctrl-vivo-btc', function ($scope, $http, $filter, dadosPagina) {
    dadosPagina.titulo = 'Best Time to Call';
    dadosPagina.descricao = 'Vivo'

    $scope.dashboard = {};
    $scope.mapa = {
        indicador: 'hitrate'
    }
    $scope.dashFiltros = {};

    // filtros iniciais
    let dtini = new Date();
    let dtfim = new Date();
    dtini.setDate(dtini.getDate() - 8);
    dtfim.setDate(dtfim.getDate() - 1);

    $scope.filtros = {
        dtini: $filter('date')(dtini, "yyyy-MM-dd"),
        dtfim: $filter('date')(dtfim, "yyyy-MM-dd"),
        campanhas: null,
        segmentacoes: null,
    };
    
    // carrega os filtros e colocar no scope
    $scope.carregarFiltros = function () {
        $http({
            method: 'GET',
            url: "/api/vivo/dashboard/filtros",
        }).then(function success(r) {
            let data = r.data;
            $scope.dashFiltros.status = r.status;
            $scope.dashFiltros.campanhas = data.Table;
            $scope.dashFiltros.segmentacoes = data.Table1;
        });
    }


    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDados = function () {
        $http({
            method: 'POST',
            url: "/api/vivo/dashboard/btc",
            data: $scope.filtros,
        }).then(function success(r) {
            $scope.dashboard.r = r;

            $scope.dashboard.hitratePorHora = r.data.Table.map(obj => ({ hora: obj.hora_descricao, value: (obj.contato * 100 / obj.discado).toFixed(1)/1 }));
            $scope.dashboard.txlocPorHora = r.data.Table.map(obj => ({ hora: obj.hora_descricao, value: (obj.cpc * 100 / obj.contato).toFixed(1) / 1 }));
            $scope.dashboard.conversaoPorHora = r.data.Table.map(obj => ({ hora: obj.hora_descricao, value: (obj.promessa * 100 / obj.cpca).toFixed(1) / 1 }));

            $scope.dashboard.quantidadePorRota = r.data.Table2.map(obj => ({ hora: obj.rota, value: obj.discado }));
            $scope.dashboard.hitratePorRota = r.data.Table2.map(obj => ({ hora: obj.rota, value: (obj.contato * 100 / obj.discado).toFixed(1) / 1 }));
            $scope.dashboard.txlocPorRota = r.data.Table2.map(obj => ({ hora: obj.rota, value: (obj.cpc * 100 / obj.contato).toFixed(1) / 1 }));

            $scope.dashboard.quantidadePorTel = r.data.Table3.map(obj => ({ hora: obj.tipo_telefone, value: obj.discado }));
            $scope.dashboard.hitratePorTel = r.data.Table3.map(obj => ({ hora: obj.tipo_telefone, value: (obj.contato * 100 / obj.discado).toFixed(1) / 1 }));
            $scope.dashboard.txlocPorTel = r.data.Table3.map(obj => ({ hora: obj.tipo_telefone, value: (obj.cpc * 100 / obj.contato).toFixed(1) / 1 }));

            $scope.carregarMapa();

        });
    }

    // carrega o mapa de acordo com o indicador escolhido
    $scope.carregarMapa = function () {
        let dados = $scope.dashboard.r.data.Table1;
        switch ($scope.mapa.indicador) {
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
                $scope.dashboard.mapa = dados.map(obj => ({ id: 'BR-' + obj.uf, value: obj[$scope.mapa.indicador] }));
        }
    }

    $scope.carregarFiltros();
    $scope.carregarDados();

});