using System;
using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Contracts;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using FakeItEasy;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.RepositoryTest
{
    class when_loaning_a_book_to_a_user_that_doesnt_exist
    {
        private static IStore _store;
        private static Repository _repository;
        private static Guid _userId;
        private static Guid _bookId;
        private static List<Book> _booksList;
        private static List<User> _usersList;
        private static bool _loanBool;

        private Establish context = () =>
        {
            _userId = Guid.NewGuid();
            _bookId = Guid.NewGuid();
            _booksList = new List<Book> { new Book { Id = _bookId, Author = "Author", ISBN = "ISBN", Title = "Title" } };
            _usersList = new List<User> { new User { Id = Guid.NewGuid(), Firstname = "Firstname", Lastname = "Lastname", BooksBorrowed = new List<Guid>() } };
            _store = A.Fake<IStore>();

            A.CallTo(() => _store.Loan(_bookId, _userId)).ReturnsLazily(() =>
            {
                try
                {
                    var book = _booksList.SingleOrDefault(b => b.Id == _bookId);

                    if (book.LoanedTo != null)
                    {
                        return false;
                    }

                    var user = _usersList.SingleOrDefault(u => u.Id == _userId);
                    book.LoanedTo = user.Id;
                    user.BooksBorrowed.Add(book.Id);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            });

            _repository = new Repository(_store);

        };

        private Because of = () =>
        {
            _loanBool = _repository.Loan(_bookId, _userId);
        };

        private It should_be_false_the_user_doesnt_exist = () => _loanBool.ShouldEqual(false);
        private It a_call_to_store_loan_should_happen = () => A.CallTo(() => _store.Loan(_bookId, _userId)).MustHaveHappened();
    }
}
