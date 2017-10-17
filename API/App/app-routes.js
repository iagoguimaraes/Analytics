angular.module('app').config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/App/Views/Home/Home.html',
            controller: 'ctrl-home'
        })

        .when('/Mktzap/Dashboard', {
            templateUrl: '/App/Views/Mktzap/Dashboard.html',
            controller: 'ctrl-mktzap-dashboard'
        })

        .when('/Mktzap/Relatorio', {
            templateUrl: '/App/Views/Mktzap/Relatorio.html',
            controller: 'ctrl-mktzap-relatorio'
        })

        .otherwise({ redirectTo: '/' });
});