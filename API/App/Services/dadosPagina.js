angular.module('app').factory('dadosPagina', function () {
    return {
        titulo: ''
        , descricao: ''
        , loading: 0
        , addLoading: function () { this.loading++; }
        , removeLoading: function () { this.loading--; }
    };
});