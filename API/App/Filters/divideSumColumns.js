angular.module('app').filter('divideSumColumns', function () {
    return function (collection, columnA, columnB) {
        var totalA = 0;
        var totalB = 0;

        collection.forEach(function (item) {
            totalA += parseInt(item[columnA]);
            totalB += parseInt(item[columnB]);
        });

        return totalA / totalB;
    };
});