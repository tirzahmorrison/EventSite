console.log("loaded")

const app = angular.module("main", ["ngRoute"])

app.config(function ($routeProvider) {

    $routeProvider.when("/", {
        templateUrl: "/Scripts/app/views/main.html",
        controller: "mainController"
    })

    $routeProvider.when("/events/:ID", {
        templateUrl: "/Scripts/app/views/event.html",
        controller: "eventController"
    })

    $routeProvider.otherwise({ redirectTo: "/" })
})

app.controller("mainController", ["$scope", "$http",
   function ($scope, $http) {
        console.log("mainController")
        $http({
            method: "GET",
            url: window.location.origin + "/events"
        }).then(resp => {
            console.dir(resp.data)
            $scope.events=_.chunk(resp.data, 3)
        })
    }
])

app.controller("eventController", ["$scope", "$routeParams", "$http",
    function ($scope, $routeParams, $http) {
        $http({
            method: "GET",
            url: window.location.origin+`/events/${$routeParams.ID}`
        }).then(resp => {
            console.dir(resp.data)
            $scope.item=resp.data
        })
    }
])
console.log("done loading")