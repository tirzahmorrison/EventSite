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
       $scope.search = () => {
           $http({
               method: "GET",
               url: window.location.origin + `/events/search?query=${$scope.query}&ageGroup=0`
           }).then(resp => {
               console.dir(resp.data)
               $scope.events = _.chunk(resp.data, 3)
           })
       }
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
        $scope.attend = () => {
            let email = prompt("please enter your email: ")
            $http({
                method: "POST",
                url: window.location.origin + `/events/${$routeParams.ID}/attendees?email=${email}`
            }).then(resp => {
                console.dir(resp.data)
                $scope.item = resp.data
            })
        }

        $scope.cancel = () => {
            let email = prompt("please enter your email: ")
            $http({
                method: "DELETE",
                url: window.location.origin + `/events/${$routeParams.ID}/attendees?email=${email}`
            }).then(resp => {
                console.dir(resp.data)
                $scope.item = resp.data
            })
        }

        $scope.joinWaitlist = () => {
            let email = prompt("please enter your email: ")
            $http({
                method: "POST",
                url: window.location.origin + `/events/${$routeParams.ID}/waitlist?email=${email}`
            }).then(resp => {
                console.dir(resp.data)
                $scope.item = resp.data
            })
        }
    }
])
console.log("done loading")