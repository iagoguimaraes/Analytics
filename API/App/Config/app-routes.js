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

       .when('/Renner/HoraHora', {
           templateUrl: '/App/Views/Renner/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-renner-horahora',
       })

       .when('/Renner/BTC', {
           templateUrl: '/App/Views/Renner/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-renner-btc',
       })

       .when('/Renner/Producao', {
           templateUrl: '/App/Views/Renner/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-renner-producao',
       })

       .when('/Vivo/HoraHora', {
           templateUrl: '/App/Views/Vivo/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-horahora',
       })

        .otherwise({ redirectTo: '/' });
});