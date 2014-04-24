﻿using System;
using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Contracts;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using FakeItEasy;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.RepositoryTest
{
    class when_returning_a_book_that_hasent_been_returned_yet
    {
        private static IStore _store;
        private static Repository _repository;
        private static Guid _userId;
        private static Guid _bookId;
        private static List<Book> _booksList;
        private static List<User> _userList;
        private static bool _returnedBool; 

        private Establish context = () =>
            {
                _userId = Guid.NewGuid();
                _bookId = Guid.NewGuid();
                _store = A.Fake<IStore>();
                _booksList = new List<Book>{new Book{Id = _bookId, Author = "Author", ISBN = "ISBN", Title = "Title", LoanedTo = _userId}};
                _userList = new List<User>{new User{Id = _userId, Firstname = "Firstname", Lastname = "Lastname", BooksBorrowed = new List<Guid>{_bookId}}};

                A.CallTo(() => _store.Return(_bookId, _userId)).ReturnsLazily(() =>
                    {
                        try
                        {
                            var book = _booksList.SingleOrDefault(b => b.Id == _bookId);

                            if (book.LoanedTo == null)
                            {
                                return false;
                            }

                            var user = _userList.SingleOrDefault(u => u.Id == _userId);
                            book.LoanedTo = null;
                            user.BooksBorrowed.Remove(book.Id);
                            return true;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }

                    });

                _repository = new Repository(_store);
            };

        private Because of = () =>
            {
                _returnedBool = _repository.Return(_bookId, _userId);
            };

        private It should_be_true_books_has_been_returned = () => _returnedBool.ShouldEqual(true);
        private It first_element_of_book_list_loaned_to_param_should_be_null = () => _booksList.SingleOrDefault(b => b.Id == _bookId).LoanedTo.ShouldBeNull();
        private It first_element_of_user_list_bookborrowed_param_should_be_empty = () => _userList.SingleOrDefault(u => u.Id == _userId).BooksBorrowed.Count.ShouldEqual(0);
        private It a_call_store_Return_should_happen = () => A.CallTo(() => _store.Return(_bookId, _userId)).MustHaveHappened();
    }
}