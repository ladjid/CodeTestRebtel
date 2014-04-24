using System;
using System.Linq;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_loaning_an_unavailable_book_to_a_user
    {
        private static Store _store;
        private static Guid _firstUserId;
        private static Guid _secondUserId;
        private static Guid _bookId;
        private static bool _loanBool;

        private Establish context = () =>
        {
            _store = new Store();
            _firstUserId = _store.GetAllUsers().ElementAt(0).Id;
            _bookId = _store.GetAllBooks().ElementAt(0).Id;
            _secondUserId = _store.GetAllUsers().ElementAt(1).Id;
            var loanBool = _store.Loan(_bookId, _firstUserId);
        };

        private Because of = () =>
        {
            _loanBool = _store.Loan(_bookId, _secondUserId);
        };

        private It loanBool_should_be_false_the_book_was_not_successfully_loaned_to_user_because_it_is_unavailable_ = () => _loanBool.ShouldEqual(false);
    }
}
