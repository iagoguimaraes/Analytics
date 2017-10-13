angular.module('app').directive('select2', function () {
    return {
        restrict: 'E',
        replace: true,
        require: 'ngModel',
        scope: {
            dados: '=',
        },
        template: '<select class="select2" multiple="multiple"></select>',
        link: function (scope, element, attr, ctrl) {
            $(element[0]).select2({
                data: scope.dados.map(obj => ({ 'id': obj[Object.keys(obj)[0]], 'text': obj[Object.keys(obj)[1]] }))
            });

            // transforma array em array de objeto
            element.bind('change', function () {
                let arrayObjt = ctrl.$modelValue.map(obj => ({ id: obj }));
                ctrl.$setViewValue(JSON.stringify(arrayObjt));
            });

        }
    }
});