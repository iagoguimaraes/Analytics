angular.module('app').config(function ($routeProvider) {
    $routeProvider

        // HOME
        .when('/', {
            templateUrl: '/App/Views/Home/Home.html?v=' + new Date().getTime(),
            controller: 'ctrl-home',
            resolve: {
                load: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load('Home');
                }]
            }
        })

        // ## ANALYTICS ##
        .when('/Analytics/Acesso', {
            templateUrl: '/App/Views/Analytics/Acesso.html?v=' + new Date().getTime(),
            controller: 'ctrl-acesso',
            resolve: {
                load: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load('Analytics/Acesso');
                }]
            }
        })
        .when('/Analytics/DiarioBordo', {
            templateUrl: '/App/Views/Analytics/DiarioBordo.html?v=' + new Date().getTime(),
            controller: 'ctrl-diariobordo',
            resolve: {
                load: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load('Analytics/DiarioBordo');
                }]
            }
        })

        // ## MKTZAP ##
        .when('/Mktzap/Dashboard', {
            templateUrl: '/App/Views/Mktzap/Dashboard.html?v=' + new Date().getTime(),
            controller: 'ctrl-mktzap-dashboard',
            resolve: {
                load: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load('Mktzap/Dashboard');
                }]
            }
        })
        .when('/Mktzap/Relatorio', {
            templateUrl: '/App/Views/Mktzap/Relatorio.html?v=' + new Date().getTime(),
            controller: 'ctrl-mktzap-relatorio',
            resolve: {
                load: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load('Mktzap/Relatorio');
                }]
            }
        })


        // ## TIM ##
       .when('/Tim/HoraHora', {
           templateUrl: '/App/Views/Tim/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-tim-horahora',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Tim/HoraHora');
               }]
           }
       })
       .when('/Tim/BTC', {
           templateUrl: '/App/Views/Tim/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-tim-btc',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Tim/BTC');
               }]
           }
       })
       .when('/Tim/Producao', {
           templateUrl: '/App/Views/Tim/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-tim-producao',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Tim/Producao');
               }]
           }
       })
       .when('/Tim/Sinergy/HoraHora', {
           templateUrl: '/App/Views/Tim/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-tim-sinergy-horahora',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Tim/SinergyHoraHora');
               }]
           }
       })


        // ## RIACHUELO ##
       .when('/Riachuelo/HoraHora', {
           templateUrl: '/App/Views/Riachuelo/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-horahora',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Riachuelo/HoraHora');
               }]
           }
       })
       .when('/Riachuelo/BTC', {
           templateUrl: '/App/Views/Riachuelo/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-btc',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Riachuelo/BTC');
               }]
           }
       })
       .when('/Riachuelo/Producao', {
           templateUrl: '/App/Views/Riachuelo/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-producao',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Riachuelo/Producao');
               }]
           }
       })
       .when('/Riachuelo/Pagamento', {
           templateUrl: '/App/Views/Riachuelo/Pagamento.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-pagamento',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Riachuelo/Pagamento');
               }]
           }
       })
       .when('/Riachuelo/Carteira', {
           templateUrl: '/App/Views/Riachuelo/Carteira.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-carteira',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Riachuelo/Carteira');
               }]
           }
       })
       .when('/Riachuelo/Efetividade', {
           templateUrl: '/App/Views/Riachuelo/Efetividade.html?v=' + new Date().getTime(),
           controller: 'ctrl-riachuelo-efetividade',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Riachuelo/Efetividade');
               }]
           }
       })


        // ## RENNER ##
       .when('/Renner/HoraHora', {
           templateUrl: '/App/Views/Renner/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-renner-horahora',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Renner/HoraHora');
               }]
           }
       })
       .when('/Renner/BTC', {
           templateUrl: '/App/Views/Renner/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-renner-btc',
        resolve: {
        load: ['$ocLazyLoad', function ($ocLazyLoad) {
            return $ocLazyLoad.load('Renner/BTC');
               }]
               }
       })
       .when('/Renner/Producao', {
           templateUrl: '/App/Views/Renner/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-renner-producao',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Renner/Producao');
               }]
           }
       })
       .when('/Renner/Pagamento', {
           templateUrl: '/App/Views/Renner/Pagamento.html?v=' + new Date().getTime(),
           controller: 'ctrl-renner-pagamento',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Renner/Pagamento');
               }]
           }
       })

        // ## VIVO ##
       .when('/Vivo/HoraHora', {
           templateUrl: '/App/Views/Vivo/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-horahora',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Vivo/HoraHora');
               }]
           }
       })
       .when('/Vivo/Producao', {
           templateUrl: '/App/Views/Vivo/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-producao',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Vivo/Producao');
               }]
           }
       })
       .when('/Vivo/BTC', {
           templateUrl: '/App/Views/Vivo/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-btc',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Vivo/BTC');
               }]
           }
       })
       .when('/Vivo/Lote', {
           templateUrl: '/App/Views/Vivo/Lote.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-lote',
        resolve: {
        load: ['$ocLazyLoad', function ($ocLazyLoad) {
            return $ocLazyLoad.load('Vivo/Lote');
               }]
               }
       })
       .when('/Vivo/Pagamento', {
           templateUrl: '/App/Views/Vivo/Pagamento.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-pagamento',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Vivo/Pagamento');
               }]
           }
       })
       .when('/Vivo/Carteira', {
           templateUrl: '/App/Views/Vivo/Carteira.html?v=' + new Date().getTime(),
           controller: 'ctrl-vivo-carteira',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Vivo/Carteira');
               }]
           }
       })

       // ## Heath for Pet ##
       .when('/Pet/HoraHora', {
           templateUrl: '/App/Views/Pet/HoraHora.html?v=' + new Date().getTime(),
           controller: 'ctrl-pet-horahora',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Pet/HoraHora');
               }]
           }
       })
       .when('/Pet/BTC', {
           templateUrl: '/App/Views/Pet/BTC.html?v=' + new Date().getTime(),
           controller: 'ctrl-pet-btc',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Pet/BTC');
               }]
           }
       })
       .when('/Pet/Producao', {
           templateUrl: '/App/Views/Pet/Producao.html?v=' + new Date().getTime(),
           controller: 'ctrl-pet-producao',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Pet/Producao');
               }]
           }
       })
       .when('/Pet/PromessaSMS', {
           templateUrl: '/App/Views/Pet/PromessaSMS.html?v=' + new Date().getTime(),
           controller: 'ctrl-pet-promessasms',
           resolve: {
               load: ['$ocLazyLoad', function ($ocLazyLoad) {
                   return $ocLazyLoad.load('Pet/PromessaSMS');
               }]
           }
       })

       .otherwise({ redirectTo: '/' });
});