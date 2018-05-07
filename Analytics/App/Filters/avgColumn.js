﻿angular.module('app').filter('avgColumn', function () {
    return function (collection, column) {
        var total = 0;

        collection.forEach(function (item) {
            total += parseInt(item[column]);
            
        });

        var result = Math.floor(total / collection.length);

       return result;
    };
});