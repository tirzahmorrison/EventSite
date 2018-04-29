const app = angular.module("main", ["ngRoute"])

app.config(($routeProvider) => {

    $routeProvider.when("/", {
        templateUrl: "/Scripts/app/views/main.html",
        controller: "mainController"
    })

    $routeProvider.when("events/: ID", {
        templateUrl: "/Scripts/app/views/event.html",
        controller: "eventController"
    })

    $routeProvider.otherwise({ redirectTo: "/" })
})

app.controller("mainController", ["$scope", "$routeParams", "$http",
    ($scope, $routeParams, $http) => {

    }
])

app.controller("eventController", ["$scope", "$routeParams", "$http",
    ($scope, $routeParams, $http) => {

    }
])