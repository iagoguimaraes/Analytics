angular.module('app').filter("formatTimer", function () {
    return function (input)  {

        function z(n) { return (n < 10 ? '0' : '') + n; }

       
        var seconds = (input % 60).toFixed(0);
        var minutes = Math.floor(input % 3600 / 60);
        var hours = Math.floor(input / 3600);

        return (z(hours) + ':' + z(minutes) + ':' + z(seconds));
    }
});