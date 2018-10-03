angular.module('app').filter('sumByColumn', function () {
    return function (collection, column) {
        var total = 0;

        collection.forEach(function (item) {
            total += (parseFloat(item[column]) || 0);
        });

        return total;
    };
});