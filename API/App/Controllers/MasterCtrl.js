angular.module('app').controller('ctrl-master', function ($scope, $http, $window, dadosPagina) {

    // dados da pagina (título, descrição etc) reusável em outros Ctrl
    $scope.dadosPagina = dadosPagina;

    // obtendo as paginas
    $http({
        method: 'GET',
        url: "/api/autenticacao/getPaginas",
    }).then(function success(r) {
        $scope.paginas = formatarMenu(r.data);
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

                // popula verificando se é uma pagina, root ou uma pasta
                let item;

                // pagina
                if (i == hierarquia.length - 1)
                    item = pagina;
                // root
                else if (i == 0)
                    item = { path: hierarquia[i], subpath: [], imagem: pagina.imagem, root: 1 };
                // pasta
                else
                    item = { path: hierarquia[i], subpath: [] };

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

});