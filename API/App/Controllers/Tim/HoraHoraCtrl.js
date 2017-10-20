angular.module('app').controller('ctrl-tim-horahora', function ($scope, $http, $filter, $interval, dadosPagina) {
    dadosPagina.titulo = 'DASHBOARD TIM';
    dadosPagina.descricao = 'Hora Hora'


    // obtem filtros do escopo e carrega os dados do dashboard
    $scope.carregarCubo = function () {
        dadosPagina.loading = true;
        $http({
            method: 'POST',
            url: "/api/tim/cubo",
            //data: $scope.filtros,
        }).then(function success(r) {
            //$scope.dashboard = r;
            console.log(r.data.Table2);


            let res = alasql('select d.disposition,sum(c.quantidade)qtd from ? c inner join ? d on d.id_disposition = c.id_disposition group by d.disposition', [r.data.Table6, r.data.Table2], function (res) {
                console.log(res);
            });
            



            dadosPagina.loading = false;
        }, function error(r) {
            alert(r.data.Message);
        });
    }


    $scope.carregarCubo();

});