angular.module('app').directive('dTable', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            dados: '=',
            info: '=',
            paging: '=',
            searching: '=',
            scrollCollapse: '=',
            scrollY: '@',
            order: '=',
        },
        template: '<table><tfoot></tfoot></table>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {

                if (!dados.length)
                    return false;

                $(element[0]).DataTable({
                    destroy: true,
                    data: dados,
                    columns: Object.keys(dados[0]).map(p => ({ title: p, data: p })),
                    language: {
                        url: '/Content/Json/datatables-lang.json'
                    },
                    info: scope.info,
                    paging: scope.paging,
                    searching: scope.searching,
                    scrollCollapse: scope.scrollCollapse,
                    scrollY: scope.scrollY,
                    order: scope.order
                });
            });
        }
    }
});