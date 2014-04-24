using System;
using System.Linq;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_returning_a_book_that_hasent_been_returned_yet
    {
        private static Store _store;
        private static User _user;
        private static Book _book;
        private static Guid _userId;
        private static Guid _bookId;
        private static bool _returnBool;

        private Establish context = () =>
            {
                _store = new Store();
                _userId = _store.GetAllUsers().ElementAt(0).Id;
                _bookId = _store.GetAllBooks().ElementAt(0).Id;
                var loanBool = _store.Loan(_bookId, _userId);
            };

        private Because of = () =>
            {
                _returnBool = _store.Return(_bookId, _userId);
                _user = _store.GetAllUsers().ElementAt(0);
                _book = _store.GetAllBooks().ElementAt(0);
            };

        private It _returnBool_should_be_true_the_book_was_successfully_returned_by_the_user_ = () => _returnBool.ShouldEqual(true);
        private It _userAfterReturn_BooksBorrowed_param_count_should_be_zero = () => _user.BooksBorrowed.Count.ShouldEqual(0);
        private It _bookAfterReturn_LoanedTo_param_should_be_equal_to_userId = () => _book.LoanedTo.ShouldBeNull();
    }
}
