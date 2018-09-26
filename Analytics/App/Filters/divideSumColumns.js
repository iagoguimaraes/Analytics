angular.module('app').filter('divideSumColumns', function () {
    return function (collection, columnA, columnB) {
        var totalA = 0;
        var totalB = 0;

        collection.forEach(function (item) {
            totalA += (parseFloat(item[columnA]) || 0);
            totalB += (parseFloat(item[columnB]) || 0);
        });

        return totalA / totalB;
    };
});