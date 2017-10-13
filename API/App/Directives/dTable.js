angular.module('app').directive('dTable', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            info: '@',
            paging: '@',
            searching: '@',
            dados: '=',
        },
        template: '<table><tfoot></tfoot></table>',
        link: function (scope, element) {
            scope.$watch('dados', function (dados) {
                $(element[0]).DataTable({
                    destroy: true,
                    info: scope.info,
                    paging: scope.paging,
                    searching: scope.searching,
                    data: dados,
                    language: {
                        url: '/Content/Json/datatables-lang.json'
                    },
                    columns: Object.keys(dados[0]).map(p => ({ title: p, data: p }))
                });
            });
        }
    }
});