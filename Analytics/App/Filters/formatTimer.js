angular.module('app').filter("formatTimer", function () {
    return function (input)  {

        function z(n) { return (n < 10 ? '0' : '') + n; }

        function x(y) {
            if (y.split(":", 0) > 0 )

            var mm = y.split(":", 0);
            var ss = y.split(":", 0);
         }

        var seconds = input % 60;
        var minutes = Math.floor(input % 3600 / 60);
        var hours = Math.floor(input / 3600);

        return (z(hours) + ':' + z(minutes) + ':' + z(seconds));
    }
});