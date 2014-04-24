using System;
using System.Linq;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_loaning_a_book_to_a_user_that_doesnt_exist
    {
        private static Store _store;
        private static Guid _bookId;
        private static bool _loanBool;

        private Establish context = () =>
        {
            _store = new Store();
            _bookId = _store.GetAllBooks().ElementAt(0).Id;
        };

        private Because of = () =>
        {
            _loanBool = _store.Loan(_bookId, Guid.NewGuid());

        };

        private It loanBool_should_be_false_the_user_does_not_exist = () => _loanBool.ShouldEqual(false);
    }
}
