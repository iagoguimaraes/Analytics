angular.module('app').config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/App/Views/Home/Home.html',
            controller: 'HomeCtrl'
        })

        .when('/Mktzap/Dashboard', {
            templateUrl: '/App/Views/Mktzap/Dashboard.html',
            controller: 'MktzapDashboardCtrl'
        })

        .when('/Mktzap/Relatorio', {
            templateUrl: '/App/Views/Mktzap/Relatorio.html',
            controller: 'MktzapRelatorioCtrl'
        })

        .otherwise({ redirectTo: '/' });
});