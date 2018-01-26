
angular.module('app').config(function ($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({
        loadedModules: ['app'], modules: [

            // HOME
            {
                name: 'Home',
                files: ['/App/Controllers/Home/HomeCtrl.js?v=2']
            },

            // ANALYTICS
            {
                name: 'Analytics/Acesso',
                files: ['/App/Controllers/Analytics/AcessoCtrl.js?=v1']
            },           
            {
                name: 'Analytics/DiarioBordo',
                files: ['/App/Controllers/Analytics/DiarioBordoCtrl.js?v=2']
            },

            // MKTZAP
            {
                name: 'Mktzap/Dashboard',
                files: ['/App/Controllers/Mktzap/DashboardCtrl.js']
            },
            {
                name: 'Mktzap/Relatorio',
                files: ['/App/Controllers/Mktzap/RelatorioCtrl.js?v=1']
            },

            // TIM
            {
                name: 'Tim/HoraHora',
                files: ['/App/Controllers/Tim/HoraHoraCtrl.js?v=2']
            },
            {
                name: 'Tim/BTC',
                files: ['/App/Controllers/Tim/BTCCtrl.js?v=3']
            },
            {
                name: 'Tim/Producao',
                files: ['/App/Controllers/Tim/ProducaoCtrl.js?v=2']
            },
            {
                name: 'Tim/SinergyHoraHora',
                files: ['/App/Controllers/Tim/SinergyHoraHoraCtrl.js?v=1']
            },

            // RIACHUELO
            {
                name: 'Riachuelo/HoraHora',
                files: ['/App/Controllers/Riachuelo/HoraHoraCtrl.js?v=1']
            },
            {
                name: 'Riachuelo/BTC',
                files: ['/App/Controllers/Riachuelo/BTCCtrl.js?v=1']
            },
            {
                name: 'Riachuelo/Producao',
                files: ['/App/Controllers/Riachuelo/ProducaoCtrl.js?v=1']
            },
            {
                name: 'Riachuelo/Pagamento',
                files: ['/App/Controllers/Riachuelo/PagamentoCtrl.js?v=1']
            },
            {
                name: 'Riachuelo/Carteira',
                files: ['/App/Controllers/Riachuelo/CarteiraCtrl.js?v=1']
            },
            {
                name: 'Riachuelo/Efetividade',
                files: ['/App/Controllers/Riachuelo/EfetividadeCtrl.js?v=1']
            },

            // RENNER
            {
                name: 'Renner/HoraHora',
                files: ['/App/Controllers/Renner/HoraHoraCtrl.js?v=1']
            },
            {
                name: 'Renner/BTC',
                files: ['/App/Controllers/Renner/BTCCtrl.js?v=1']
            },
            {
                name: 'Renner/Producao',
                files: ['/App/Controllers/Renner/ProducaoCtrl.js?v=1']
            },
            {
                name: 'Renner/Pagamento',
                files: ['/App/Controllers/Renner/PagamentoCtrl.js?v=1']
            },

            // VIVO
            {
                name: 'Vivo/HoraHora',
                files: ['/App/Controllers/Vivo/HoraHoraCtrl.js?v=5']
            },
            {
                name: 'Vivo/Producao',
                files: ['/App/Controllers/Vivo/ProducaoCtrl.js?v=4']
            },
            {
                name: 'Vivo/BTC',
                files: ['/App/Controllers/Vivo/BTCCtrl.js?v=1']
            },
            {
                name: 'Vivo/Lote',
                files: ['/App/Controllers/Vivo/LoteCtrl.js?v=1']
            },
            {
                name: 'Vivo/Pagamento',
                files: ['/App/Controllers/Vivo/PagamentoCtrl.js?v=1']
            },
            {
                name: 'Vivo/Carteira',
                files: ['/App/Controllers/Vivo/CarteiraCtrl.js?v=1']
            },

            // PET
            {
                name: 'Pet/HoraHora',
                files: ['/App/Controllers/Pet/HoraHoraCtrl.js?v=1']
            },
            {
                name: 'Pet/BTC',
                files: ['/App/Controllers/Pet/BTCCtrl.js?v=1']
            },
            {
                name: 'Pet/Producao',
                files: ['/App/Controllers/Pet/ProducaoCtrl.js?v=2']
            },
            {
                name: 'Pet/PromessaSMS',
                files: ['/App/Controllers/Pet/PromessaSMSCtrl.js?v=2']
            },


        ]
    });
});






