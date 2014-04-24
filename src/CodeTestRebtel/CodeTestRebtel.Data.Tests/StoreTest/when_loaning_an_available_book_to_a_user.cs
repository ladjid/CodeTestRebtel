using System;
using System.Linq;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_loaning_an_available_book_to_a_user
    {
        private static Store _store;
        private static User _user;
        private static Book _book;
        private static Guid _userId;
        private static Guid _bookId;
        private static bool _loanBool;

        private Establish context = () =>
        {
            _store = new Store();
            _userId = _store.GetAllUsers().ElementAt(0).Id;
            _bookId = _store.GetAllBooks().ElementAt(0).Id; 
        };

        private Because of = () =>
            {
                _loanBool = _store.Loan(_bookId, _userId);
                _user = _store.GetAllUsers().ElementAt(0);
                _book = _store.GetAllBooks().ElementAt(0);
            };

        private It loanBool_should_be_true_the_book_was_successfully_loaned_to_user_ = () => _loanBool.ShouldEqual(true);
        private It user_BooksBorrowed_param_should_contain_bookId = () => _user.BooksBorrowed.Contains(_bookId).ShouldBeTrue();
        private It book_LoanedTo_param_should_be_equal_to_userId = () => _book.LoanedTo.ShouldEqual(_userId);
    }
}
