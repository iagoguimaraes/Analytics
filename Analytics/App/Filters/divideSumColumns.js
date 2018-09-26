angular.module('app').filter('divideSumColumns', function () {
    return function (collection, columnA, columnB) {
        var totalA = 0;
        var totalB = 0;

        collection.forEach(function (item) {
            totalA += parseInt(item[columnA]) || 0;
            totalB += parseInt(item[columnB]) || 0;
        });

        return totalA / totalB;
    };
});