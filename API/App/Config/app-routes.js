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

        .when('/Tim/HoraHora', {
            templateUrl: '/App/Views/Tim/HoraHora.html?v=' + new Date().getTime(),
            controller: 'ctrl-tim-horahora',
        })

       .when('/Tim/BTC', {
           templateUrl: '/App/Views/Tim/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-tim-btc',
       })

       .when('/Tim/Producao', {
                   templateUrl: '/App/Views/Tim/Producao.html?v=' + new Date().getTime(),
                   controller: 'ctrl-tim-producao',
       })

       .when('/Riachuelo/HoraHora', {
           templateUrl: '/App/Views/Riachuelo/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-horahora',
       })

       .when('/Riachuelo/BTC', {
           templateUrl: '/App/Views/Riachuelo/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-btc',
       })

       .when('/Riachuelo/Producao', {
           templateUrl: '/App/Views/Riachuelo/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-producao',
       })

        .otherwise({ redirectTo: '/' });
});