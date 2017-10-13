angular.module('app', ['ngRoute']).config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Views/Home.html',
            controller: 'HomeController'
        })

        // route for the about page
        .when('/Dashboard/Mktzap', {
            templateUrl: 'Views/Dashboard/Mktzap.html',
            controller: 'MktzapController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'pages/contact.html',
            controller: 'contactController'
        });
});