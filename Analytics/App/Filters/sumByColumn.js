angular.module('app').filter('sumByColumn', function () {
    return function (collection, column) {
        var total = 0;

        collection.forEach(function (item) {
            total += parseInt(item[column]);
        });

        return total;
    };
});