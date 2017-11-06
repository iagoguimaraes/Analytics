angular.module('app').controller('ctrl-home', function ($scope, $http, dadosPagina) {
    dadosPagina.titulo = 'Página Inicial'
    dadosPagina.descricao = 'Seja Bem-Vindo!'
});