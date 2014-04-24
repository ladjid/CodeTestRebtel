using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Contracts;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using FakeItEasy;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.RepositoryTest
{
    class when_retrieving_all_users_from_an_empty_user_list
    {
        private static IStore _store;
        private static Repository _repository;
        private static IEnumerable<User> _users;

        private Establish context = () =>
        {
            _store = A.Fake<IStore>();
            var userlist = new List<User>();
            A.CallTo(() => _store.GetAllUsers()).Returns(userlist);
            _repository = new Repository(_store);
        };

        private Because of = () =>
        {
            _users = _repository.GetAllUsers();
        };

        private It book_list_count_should_be_zero = () => _users.Count().ShouldEqual(0);
        private It a_call_to_store_GetAllUsers_should_happen = () => A.CallTo(() => _store.GetAllUsers()).MustHaveHappened();

    }
}
