angular.module('app').controller('HomeController', ['$scope', '$http', function ($scope, $http) {

    // TESTANDO PAGINAS
    $http({
        method: 'GET',
        url: "/api/autenticacao/getPaginas",
    }).then(function success(r) {
        $scope.paginas = r.data;
        console.log(formatarMenu(r.data));
    }, function error(r) {
        alert(r.data.Message);
    });

    // formata o menu hierarquicamente para usar no ng-repeat
    function formatarMenu(paginas) {
        // inicializa o menu formatado
        let menu = { path: 'menu', subpath: [] };

        // varre todas as paginas da lista
        paginas.forEach(function (pagina) {
            // quebra cada item da hierarquia
            let hierarquia = pagina.path.split('/');

            // varre toda a hierarquia da pagina (inicializa o diretoria atual com o menu root)
            for (let i = 0, atual = menu; i < hierarquia.length; i++) {

                // popula verificando se é uma pagina ou uma pasta
                let item = i == hierarquia.length - 1 ? pagina : { path: hierarquia[i], subpath: [] };
                
                // procura este item dentro da hierarquia
                let find = atual.subpath.find(f => f.path === item.path);

                // se não encontrar adiciona
                if (find === undefined)
                    atual.subpath.push(item);
                   
                // seta o diretorio atual de pesquisa para o item adicionado (ou ja existente)
                atual = atual.subpath.find(f => f.path === item.path);
            }
        });
        // retorna
        return menu;
    }

}]);