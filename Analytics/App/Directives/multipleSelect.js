angular.module('app').directive('multipleSelect', function () {
    return {
        restrict: 'E',
        replace: true,
        require: 'ngModel',
        scope: {
            dados: '=',
            filter: '@',
            width: '@'
        },
        template: '<select multiple="multiple"></select>',
        link: function (scope, element, attr, ctrl) {

            for (var i = 0; i < scope.dados.length; i++) {
                option = document.createElement('option');
                option.value = option.text = scope.dados[i];
                element[0].add(option);
            }

            $(element[0]).multipleSelect({
                filter: scope.filter,
                width: scope.width || '100%',
            });

        }
    }
});