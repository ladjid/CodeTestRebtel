using System;
using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Contracts;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;
using FakeItEasy;

namespace CodeTestRebtel.Data.Tests.RepositoryTest
{
    class when_retrieving_all_users
    {
        private static IStore _store;
        private static Repository _repository;
        private static IEnumerable<User> _users;
        private static List<User> _userList; 
        private static Guid _userId1;
        private static Guid _userId2;

        private Establish context = () =>
            {
                _userId1 = Guid.NewGuid();
                _userId2 = Guid.NewGuid();
                _store = A.Fake<IStore>();
                _userList = new List<User>
                    {
                        new User {Id = _userId1, Firstname = "Firstname", Lastname = "Lastname"},
                        new User {Id = _userId2, Firstname = "Firstname 2", Lastname = "Lastname 2"}
                    };
                A.CallTo(() => _store.GetAllUsers()).Returns(_userList);
                _repository = new Repository(_store);
            };

        private Because of = () =>
            {
                _users = _repository.GetAllUsers();
            };

        private It the_returned_user_list_should_be_greater_than_zero = () => _users.Count().ShouldBeGreaterThan(0);
        private It the_id_of_the_first_element_in_the_user_list_should_equal_userId1 = () => _users.SingleOrDefault(b => b.Id == _userId1).Id.ShouldEqual(_userId1);
        private It the_id_of_the_second_element_in_the_user_list_should_equal_userId2 = () => _users.SingleOrDefault(b => b.Id == _userId2).Id.ShouldEqual(_userId2);
        private It a_call_to_store_GetAllUsers_should_happen = () => A.CallTo(() => _store.GetAllUsers()).MustHaveHappened();
    }
}
