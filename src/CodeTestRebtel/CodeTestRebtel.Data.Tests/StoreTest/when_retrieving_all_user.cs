using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_retrieving_all_user
    {
        private static Store _store;
        private static IEnumerable<User>_usersList;

        private Establish context = () =>
        {
            _store = new Store();
        };

        private Because of = () =>
        {
            _usersList = _store.GetAllUsers();
        };

        private It _user_list_count_should_be_greater_than_zero = () => _usersList.Count().ShouldBeGreaterThan(0);
    }
}
