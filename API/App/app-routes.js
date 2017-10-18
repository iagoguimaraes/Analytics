angular.module('app').config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/App/Views/Home/Home.html?v=' + new Date().getTime(),
            controller: 'ctrl-home'
        })

        .when('/Mktzap/Dashboard', {
            templateUrl: '/App/Views/Mktzap/Dashboard.html?v=' + new Date().getTime(),
            controller: 'ctrl-mktzap-dashboard'
        })

        .when('/Mktzap/Relatorio', {
            templateUrl: '/App/Views/Mktzap/Relatorio.html?v=' + new Date().getTime(),
            controller: 'ctrl-mktzap-relatorio'
        })

        .otherwise({ redirectTo: '/' });
});