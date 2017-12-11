angular.module('app').controller('ctrl-acesso', function ($scope, $http, dadosPagina) {
    dadosPagina.titulo = 'Controle de Acessos'
    dadosPagina.descricao = ''

    $scope.model = {
        grupo: 1
    };

    //carregar os grupos
    $http({
        method: 'GET',
        url: "/api/analytics/grupo/consultar",
    }).then(function success(r) {
        $scope.statusGrupo = r.status;
        $scope.grupos = r.data.Table;
        $scope.popularAcessos();
    });

    $scope.popularAcessos = function () {
        $http({
            method: 'POST',
            url: "/api/analytics/acesso/consultar",
            data: $scope.model,
        }).then(function success(r) {
            $scope.statusAcesso = r.status;
            $scope.paginas = r.data.Table;
            $scope.recursos = r.data.Table1;
        });
    };

    $scope.alterarPagina = function (item) {
        if (item.selected) {
            $http({
                method: 'POST',
                url: "/api/analytics/acesso/pagina/inserir",
                data: {
                    id_pagina: item.id_pagina,
                    id_grupo: $scope.model.grupo
                }
            })
        }
        else {
            $http({
                method: 'POST',
                url: "/api/analytics/acesso/pagina/remover",
                data: {
                    id_pagina: item.id_pagina,
                    id_grupo: $scope.model.grupo
                }
            })
        }
    };

    $scope.alterarRecurso = function (item) {
        if (item.selected) {
            $http({
                method: 'POST',
                url: "/api/analytics/acesso/recurso/inserir",
                data: {
                    id_recurso: item.id_recurso,
                    id_grupo: $scope.model.grupo
                }
            })
        }
        else {
            $http({
                method: 'POST',
                url: "/api/analytics/acesso/recurso/remover",
                data: {
                    id_recurso: item.id_recurso,
                    id_grupo: $scope.model.grupo
                }
            })
        }
    };

});