angular.module('ServiceModule', [])
    .service('services', ['$http', function ($http) {
        return {
            getAllBooks : function() {
                return $http.get('BookData/GetAllBooks').then(function (data) {
                    return data.data;
                }, function(data) {
                    return data.status;
                });
            },
            getAllUsers : function() {
                return $http.get('BookData/GetAllUsers').then(function(data) {
                    return data.data;
                }, function(data) {
                    return data.status;
                });
            },
            loan: function (bookId, userId) {
                return $http.get('BookData/Loan', { params: { bookId: bookId, userId: userId } }).then(function (data) {
                    return data.data;
                }, function(data) {
                    return data.status;
                });
            },
            returns : function(bookId, userId) {
                return $http.get('BookData/Return', { params: { bookId: bookId, userId: userId }}).then(function(data) {
                    return data.data;
                }, function(data) {
                    return data.data;
                });
            },
        
            filter: function (filter) {
                return $http.get('BookData/FilterBooks', { params: { filter: filter } }).then(function (data) {
                    return data.data;
                }, function(data) {
                    return data.status;
                });
            }
         };
    }])