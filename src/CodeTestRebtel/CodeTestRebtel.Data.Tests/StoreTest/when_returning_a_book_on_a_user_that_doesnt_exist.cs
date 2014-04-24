using System;
using System.Linq;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_returning_a_book_on_a_user_that_doesnt_exist
    {
        private static Store _store;
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
            _returnBool = _store.Return(_bookId, Guid.NewGuid());
        };

        private It _returnBool_should_be_false_the_user_does_not_exist_ = () => _returnBool.ShouldEqual(false);
    }
}
