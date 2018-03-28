angular.module('app').factory('cubo', function () {
    let service = {};
    let dados = [];
    let dadosFiltrados = [];
    let filtros = [];

    // carrega os dados
    service.carregar = function (_dados) {
        dados = _dados;
        dadosFiltrados = _dados;
    }

    // obtem os dados filtrados
    service.obter = function () {
        return dadosFiltrados;
    }

    // obter listagem de uma dimensao (dos dados filtrados)
    service.obterDimensao = function (campo) {
        return alasql('select distinct ' + campo + ' from ?', [dadosFiltrados]).map(o => o[campo]);
    }

    // adicionar um filtro
    service.filtrar = function (campo, filtro) {
        filtros.push({ campo: campo, filtro: filtro });
    };

    // limpar os filtros
    service.limparFiltros = function () {
        dadosFiltrados = dados;
        filtros = [];
    }

    // aplicar os filtros
    service.aplicarFiltros = function () {
        dadosFiltrados = dados;
        for (var i = 0; i < filtros.length; i++) {
            let campo = filtros[i].campo;
            let filtro = filtros[i].filtro;

            if (filtro && filtro.length > 0)
                dadosFiltrados = dadosFiltrados.filter(d => filtro.indexOf(d[campo]) > -1);
        }
    }

    service.query = function (query) {
        return alasql(query, [dadosFiltrados]);
    }

    return service;
});