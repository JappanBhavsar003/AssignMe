/// <reference path="angularRouter.js" />
/// <reference path="commonFunc.js" />
/// <reference path="angular.min.js" />
var assignMe = angular.module('AssignMe', ['ui.router', 'angular-loading-bar']);

assignMe.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('login');

    $stateProvider

        // state - Login
        .state('login', {
            url: '/login',
            templateUrl: '/templates/login.html',
            controller: 'LoginController'
        })

         .state('signup', {
             url: '/signup',
             templateUrl: '/templates/signup.html',
             controller: 'SignupController'

         })

        .state('dashboard', {
            url: '/dashboard',
            templateUrl: '/templates/dashboard.html',
            controller: 'DashboardController'

        });


})

assignMe.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
     cfpLoadingBarProvider.includeSpinner = true;
 }])

assignMe.run(function () {


})

assignMe.factory('assignFactory',function ($q, $http) {
    return {

        // call() - For calling api
        call: function (api, parameter, done, error, fail) {
            // Simple GET request example:
            $http({
                method: 'POST',
                url: api,
                data: JSON.stringify(parameter)
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available
                if (response.error) {
                    error(response.data);
                } else {
                    done(response.data);
                }

            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                fail(response);
            });
        }

    }
})

assignMe.constant(function () {


})

assignMe.service('assignServices',function(){



})