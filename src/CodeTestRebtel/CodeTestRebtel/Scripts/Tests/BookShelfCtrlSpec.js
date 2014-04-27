var httpBackend;
var injector;
var ctrlScope;
var ctrl;
var services;
var BookShelfCtrl;
var books = [
    { "Id": 43434, "Author": "Author", "Title": "Title", "ISBN": "ISBN", "LoanedTo": "LoanedTo", "LoanedToName": "LoanedToName" },
    { "Id": 43434, "Author": "Author 1", "Title": "Title 1", "ISBN": "ISBN 1", "LoanedTo": "LoanedTo 1", "LoanedToName": "LoanedToName 2" }];

module('BookShelfCtrlSpec', {
    setup: function () {

        var appMocks = angular.module('appMocks', []);
        appMocks.config(function ($provide) {
            $provide.decorator('$httpBackend', angular.mock.e2e.$httpBackendDecorator);
        });

        injector = angular.injector(['ng', 'appMocks', 'ServiceModule', 'BookShelf']);
        httpBackend = injector.get('$httpBackend');
        ctrlScope = injector.get('$rootScope').$new();

        services = injector.get('services');
        sinon.stub(services, 'getAllBooks', services.getAllBooks);
        sinon.stub(services, 'getAllUsers', services.getAllUsers);
        sinon.stub(services, 'loan', services.loan);
        sinon.stub(services, 'returns', services.returns);
        sinon.stub(services, 'filter', services.filter);
        
        ctrl = injector.get('$controller')('BookShelfCtrl', { $scope: ctrlScope, services: services });
       
    },
    teardown: function () {

        services.getAllBooks.restore();
        services.getAllUsers.restore();
        services.loan.restore();
        services.returns.restore();
        services.filter.restore();
    }
});

test('When retrieving all books', function() {

    httpBackend.expectGET('BookData/GetAllBooks').respond(books);
    ctrlScope.getAllBooks();
    httpBackend.flush();
    notEqual(ctrlScope.books.length, 0, "The length of the book array should be greater than 0");
})