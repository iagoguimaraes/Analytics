angular.module('app').directive('datePicker', function () {
    return {
        restrict: 'E',
        replace: true,
        require: 'ngModel',
        scope: {
        },
        template: '<input type="text"/>',
        link: function (scope, element, attr, ctrl) {
            $(element[0]).datepicker({
                format: 'yyyy-mm-dd'
                ,autoclose: true
                ,ignoreReadonly: true
                ,allowInputToggle: true
            });
        }
    }
});