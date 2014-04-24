using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_retrieving_all_users_from_an_empty_user_list
    {
        private static Store _store;
        private static IEnumerable<User> _usersList;

        private Establish context = () =>
        {
            _store = new Store(true);
        };

        private Because of = () =>
        {
            _usersList = _store.GetAllUsers();
        };

        private It _user_list_count_should_be_zero = () => _usersList.Count().ShouldEqual(0);
    }
}
