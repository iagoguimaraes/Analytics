angular.module('app').filter('corrigePercent', ['$filter', function ($filter) {
    return function (input, decimals) {

        return input > 1 ? 1 : input;
    };
}]);