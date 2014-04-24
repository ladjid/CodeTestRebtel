angular.module('ServiceModule', [])
    .service('services', ['$http', function ($http) {
        return {
            GetAllBooks : function() {
                return $http.get('BookData/GetAllBooks').then(function (data) {
                    return data.data;
                }, function(data) {
                    return data.status;
                });
            },
            GetAllUsers : function() {
                return $http.get('BookData/GetAllUsers').then(function(data) {
                    return data.data;
                }, function(data) {
                    return data.status;
                });
            },
            Loan : function(bookId, userId) {
                return $http.post('BookData/Loan', {bookId:bookId, userId:userId}).then(function(data) {
                    return data.data;
                }, function(data) {
                    return data.status;
                });
            },
            Return : function(bookId, userId) {
                return $http.post('BookData/Return', { bookId: bookId, userId: userId }).then(function(data) {
                    return data.data;
                }, function(data) {
                    return data.data;
                });
            },
            Filter : function(filter) {
                return $http.get('BookData/FilterBooks', { filter: filter }).then(function(data) {
                    return data.data;
                }, function(data) {
                    return data.status;
                });
            }
         };
    }])