angular.module('app').config(function ($routeProvider) {
    $routeProvider

        // HOME
        .when('/', {
            templateUrl: '/App/Views/Home/Home.html?v=' + new Date().getTime(),
            controller: 'ctrl-home'
        })

        // ## ANALYTICS ##
        .when('/Analytics/Acesso', {
            templateUrl: '/App/Views/Analytics/Acesso.html?v=' + new Date().getTime(),
            controller: 'ctrl-acesso'
        })
       .when('/Analytics/DiarioBordo', {
           templateUrl: '/App/Views/Analytics/DiarioBordo.html?v=' + new Date().getTime(),
           controller: 'ctrl-diariobordo',
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
       .when('/Tim/Sinergy/HoraHora', {
           templateUrl: '/App/Views/Tim/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-tim-sinergy-horahora',
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
       .when('/Riachuelo/Efetividade', {
            templateUrl: '/App/Views/Riachuelo/Efetividade.html?v=' + new Date().getTime(),
            controller: 'ctrl-riachuelo-efetividade',
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
       .when('/Vivo/Lote', {
            templateUrl: '/App/Views/Vivo/Lote.html?v=' + new Date().getTime(),
            controller: 'ctrl-vivo-lote',
       })
       .when('/Vivo/Pagamento', {
            templateUrl: '/App/Views/Vivo/Pagamento.html?v=' + new Date().getTime(),
            controller: 'ctrl-vivo-pagamento',
       })
       .when('/Vivo/Carteira', {
           templateUrl: '/App/Views/Vivo/Carteira.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-carteira',
       })

       // ## Heath for Pet ##
       .when('/Pet/HoraHora', {
           templateUrl: '/App/Views/Pet/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-pet-horahora',
       })
       .when('/Pet/BTC', {
           templateUrl: '/App/Views/Pet/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-pet-btc',
       })
       .when('/Pet/Producao', {
           templateUrl: '/App/Views/Pet/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-pet-producao',
       })
       .when('/Pet/PromessaSMS', {
           templateUrl: '/App/Views/Pet/PromessaSMS.html?v=' + new Date().getTime(),
           controller: 'ctrl-pet-promessasms',
       })

       .otherwise({ redirectTo: '/' });
});