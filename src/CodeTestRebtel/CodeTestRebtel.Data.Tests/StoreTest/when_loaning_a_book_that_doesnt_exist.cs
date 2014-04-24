using System;
using System.Linq;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_loaning_a_book_that_doesnt_exist
    {
        private static Store _store;
        private static Guid _userId;
        private static bool _loanBool;

        private Establish context = () =>
        {
            _store = new Store();
            _userId = _store.GetAllUsers().ElementAt(0).Id;
        };

        private Because of = () =>
        {
            var loanBool = _store.Loan(Guid.NewGuid(), _userId);
        };

        private It loanBool_should_be_false_the_book_does_not_exist_ = () => _loanBool.ShouldEqual(false);
    }
}
