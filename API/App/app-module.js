angular.module('app', ['ngRoute'], function () { });

// ao iniciar
angular.module('app').run(function ($locale) {
    // formato de numero
    $locale.NUMBER_FORMATS.GROUP_SEP = ".";
    $locale.NUMBER_FORMATS.DECIMAL_SEP = ",";
});