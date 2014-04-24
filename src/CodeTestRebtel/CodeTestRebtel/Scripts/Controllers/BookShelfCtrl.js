angular.module('BookShelf')
    .controller('BookShelfCtrl', ['$scope', 'services','$http', function ($scope, services, $http) {

        services.GetAllBooks().then(function (data) {
            $scope.books = data;
        });
    }])