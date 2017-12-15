angular.module('app').directive('timePicker', function () {
    return {
        restrict: 'E',
        replace: true,
        require: 'ngModel',
        scope: {
        },
        template: '<input class="timepicker" type="text"/>',
        link: function (scope, element, attr, ctrl) {
            $(element[0]).timepicker({
                showSeconds: false,
                showMeridian: false,
                defaultTime: new Date().getHours() + ':' +  new Date().getMinutes()
            });
        }
    }
});