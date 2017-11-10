angular.module('app').controller('ctrl-home', function ($scope, $http, dadosPagina) {
    dadosPagina.titulo = 'Seja Bem-Vindo!'
    dadosPagina.descricao = 'Credit Cash Analytics'
});