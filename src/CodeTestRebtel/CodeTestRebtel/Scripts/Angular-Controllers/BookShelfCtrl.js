angular.module('BookShelf')
    .controller('BookShelfCtrl', ['$scope', 'services', function ($scope, services) {

        $scope.filter = "";
        $scope.userSelected = null;
       
        $scope.getAllBooks = function () {

            services.getAllBooks().then(function (data) {
                $scope.books = data;
            });
        };

        $scope.getAllUsers = function () {

            services.getAllUsers().then(function (data) {
                $scope.users = data;
            });
        };
        
        $scope.loan = function () {

            if ($scope.userSelected != null) {
                
                services.loan($scope.bookChosen.Id, $scope.userSelected.Id).then(function (data) {
                    $scope.loanResponse = data;
                    $scope.getAllBooks();
                    $scope.hideModal();
                });

            } else {

                $scope.didNotSelectAnyUser = true;
            }
        };

        $scope.return = function (book) {

            services.returns(book.Id, book.LoanedTo).then(function (data) {
                $scope.returnResponse = data;
                $scope.getAllBooks();
            });
        };

        $scope.$watch('filter', function (filter) {
            services.filter(filter).then(function (data) {
                $scope.books = data;
            });
        });

        $scope.showModal = function (bookChosen) {

            $scope.modalVisible = true;
            $scope.bookChosen = bookChosen;
        };

        $scope.hideModal = function () {

            $scope.modalVisible = false;
            $scope.bookChosen = null;
            $scope.userSelected = null;
            $scope.didNotSelectAnyUser = false;
        };

        $scope.Initiate = function () {
            $scope.getAllBooks();
            $scope.getAllUsers();
        };
}])