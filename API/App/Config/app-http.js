angular.module('app').config(function ($httpProvider, $windowProvider) {

    // se não tiver token na sessao redireciona para pagina de login
    if (localStorage.getItem('token') === null) {
        let $window = $windowProvider.$get();
        $window.location.href = 'Login.html'
    }

    // setando o token no header das requisições
    $httpProvider.defaults.headers.common['Token'] = localStorage.getItem('token');
    // Use x-www-form-urlencoded Content-Type
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
    // Override $http service's default transformRequest
    $httpProvider.defaults.transformRequest = [function (data) {
        return angular.isObject(data) && String(data) !== '[object File]' ? $.param(data) : data;
    }];
    // tirando cache das requisições
    $httpProvider.defaults.cache = false

    // adicioanr o interceptor
    $httpProvider.interceptors.push('httpInterceptor');
    
});