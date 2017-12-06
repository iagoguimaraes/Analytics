angular.module('app').controller('ctrl-vivo-horahora', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'Hora Hora';
    dadosPagina.descricao = 'Vivo'

    $scope.filtros = {
        data: $filter('date')(new Date(), "yyyy-MM-dd"),
        campanhas: '',
        segmentacoes: ''
    };
    $scope.dashFiltros = {};
    $scope.dashboard = {};
    $scope.grafico = { indicador: 'hitrate' };
    $scope.diagrama = { dados: [], navegacoes: [], navegacao: null };

    //carregar os filtros
    $http({
        method: 'GET',
        url: "/api/vivo/dashboard/filtros",
        data: $scope.filtros,
    }).then(function success(r) {
        let data = r.data;
        $scope.dashFiltros.status = r.status;
        $scope.dashFiltros.campanhas = data.Table;
        $scope.dashFiltros.segmentacoes = data.Table1;
    });

    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarDashboard = function () {
        $http({
            method: 'POST',
            url: "/api/vivo/dashboard/horahora",
            data: $scope.filtros,
        }).then(function success(r) {
            let data = r.data;
            $scope.dashboard.status = r.status;
            $scope.dashboard.resumo = data.Table[0];
            $scope.dashboard.produto = data.Table1;
            $scope.dashboard.horahora = data.Table2;
            $scope.diagrama.dados = data.Table3;
            $scope.dashboard.discador = data.Table4;

            $scope.carregarFiltroDiagrama();
            $scope.carregarDiagrama();
            $scope.carregarGrafico();
        });
    }

    // carrega o filtro com as navegacoes disponiveis
    $scope.carregarFiltroDiagrama = function () {
        $scope.diagrama.navegacoes = $scope.diagrama.dados.reduce(
        function (total, item) {
            let n = { id_navegacao: item.id_navegacao, descricao: item.descricao };
            if (!total.some(x => x.id_navegacao == n.id_navegacao))
                total.push(n);

            return total;
        }, []);

        $scope.diagrama.navegacao = $scope.diagrama.navegacoes[0].id_navegacao;
    };

    // carregar o diagrama de acordo com a navegação escolhida
    $scope.carregarDiagrama = function () {
        let navegacao = $scope.diagrama.navegacao;
        $scope.dashboard.diagrama = $scope.diagrama.dados.filter(obj => obj.id_navegacao == navegacao);
    };

    // carrega o grafico de acordo com o indicador escolhido
    $scope.carregarGrafico = function () {
        let dados = $scope.dashboard.horahora;
        switch ($scope.grafico.indicador) {
            case 'hitrate':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.hora, value: (obj.contato * 100 / obj.discado).toFixed(1) }));
                break;
            case 'txloc':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.hora, value: (obj.cpc * 100 / obj.contato).toFixed(1) }));
                break;
            case 'txapv':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.hora, value: (obj.cpca * 100 / obj.cpc).toFixed(1) }));
                break;
            case 'conversao':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.hora, value: (obj.promessa * 100 / obj.cpca).toFixed(1) }));
                break;
            case 'ocupacao':
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.hora, value: (obj.falado_ad * 100 / 3600).toFixed(1) }));
                break;
            default:
                $scope.dashboard.grafico = dados.map(obj => ({ data: obj.hora, value: obj[$scope.grafico.indicador] }));
        }
    }

    $scope.carregarDashboard();

});