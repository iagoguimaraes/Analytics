angular.module('app').config(function ($routeProvider) {
    $routeProvider

        // HOME
        .when('/', {
            templateUrl: '/App/Views/Home/Home.html?v=' + new Date().getTime(),
            controller: 'ctrl-home'
        })


        // ## MKTZAP ##
        .when('/Mktzap/Dashboard', {
            templateUrl: '/App/Views/Mktzap/Dashboard.html?v=' + new Date().getTime(),
            controller: 'ctrl-mktzap-dashboard'
        })
        .when('/Mktzap/Relatorio', {
            templateUrl: '/App/Views/Mktzap/Relatorio.html?v=' + new Date().getTime(),
            controller: 'ctrl-mktzap-relatorio'
        })


        // ## TIM ##
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


        // ## RIACHUELO ##
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
       .when('/Riachuelo/Pagamento', {
           templateUrl: '/App/Views/Riachuelo/Pagamento.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-pagamento',
       })
        .when('/Riachuelo/Carteira', {
            templateUrl: '/App/Views/Riachuelo/Carteira.html?v=' + new Date().getTime(),
            controller: 'ctrl-riachuelo-carteira',
        })

        // ## RENNER ##
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

        // ## VIVO ##
       .when('/Vivo/HoraHora', {
           templateUrl: '/App/Views/Vivo/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-horahora',
       })
       .when('/Vivo/Producao', {
           templateUrl: '/App/Views/Vivo/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-producao',
       })
       .when('/Vivo/BTC', {
           templateUrl: '/App/Views/Vivo/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-btc',
       })

        .otherwise({ redirectTo: '/' });
});