// SELECT QUE USA OBJETO {ID, e TEXT}
angular.module('app').directive('select2', function () {
    return {
        restrict: 'E',
        replace: true,
        require: 'ngModel',
        scope: {
            dados: '=',
        },
        template: '<select class="select2" multiple="multiple" readonly="true"></select>',
        link: function (scope, element, attr, ctrl) {
            $(element[0]).select2({
                data: scope.dados.map(obj => ({ 'id': obj[Object.keys(obj)[0]], 'text': obj[Object.keys(obj)[1]] })),
                allowClear: true,
            });

            // transforma array em array de objeto
            element.bind('change', function () {
                let arrayObjt = ctrl.$modelValue.map(obj => ({ id: obj }));
                let viewValue = arrayObjt.length ? JSON.stringify(arrayObjt) : null; // ou retorna lista com itens ou null (serializador C#)
                ctrl.$setViewValue(viewValue);
            });

        }
    }
});

// SELECT QUE USA ARRAY DE STRING DIRETO
angular.module('app').directive('select22', function () {
    return {
        restrict: 'E',
        replace: true,
        require: 'ngModel',
        scope: {
            dados: '=',
        },
        template: '<select class="select2" multiple="multiple" readonly="true"></select>',
        link: function (scope, element, attr, ctrl) {
            $(element[0]).select2({
                data: scope.dados.map(obj => ({ 'id': obj, 'text': obj })),
                allowClear: true,
            });
        }
    }
});