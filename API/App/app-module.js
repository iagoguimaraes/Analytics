angular.module('app', [], function ($httpProvider) {
    // setando o token no header das requisições
    $httpProvider.defaults.headers.common['Token'] = localStorage.getItem('token');
    // Use x-www-form-urlencoded Content-Type
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
    // Override $http service's default transformRequest
    $httpProvider.defaults.transformRequest = [function (data) {
        return angular.isObject(data) && String(data) !== '[object File]' ? $.param(data) : data;
    }];
});