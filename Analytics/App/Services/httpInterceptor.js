angular.module('app').factory('httpInterceptor', function ($q, $window, $location, dadosPagina) {
    return {

        'request': function (config) {
            dadosPagina.addLoading();
            return config;
        },

        'response': function (response) {
            dadosPagina.removeLoading();
            return response;
        },

        'responseError': function (rejection) {
            dadosPagina.removeLoading();

            if (rejection.status === 401) {
                alert('Sua sessão não existe ou expirou');
                $window.location.href = '/login.html';
            }
            else if(rejection.status === 403){
                alert('Você não tem permissão a este recurso');
                $location.path('/');
            }
            else if(rejection.status === 500){
                alert('Erro ao processar requisição');
                console.log(rejection);
            }

            return rejection;
        }
    };
});