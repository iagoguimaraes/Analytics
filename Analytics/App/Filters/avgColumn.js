angular.module('app').filter('avgColumn', function () {
    return function (collection, column) {
        var total = 0;

        collection.forEach(function (item) {
            total += (parseFloat(item[column]) || 0);
            
        });

        var result = Math.floor(total / collection.length);

       return result;
    };
});