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
    class when_retrieving_all_books
    {
        private static IStore _store;
        private static Repository _repository;
        private static IEnumerable<Book> _books;
        private static List<Book> _booksList;  
        private static Guid _bookId1;
        private static Guid _bookId2;

        private Establish context = () =>
            {
                _bookId1 = Guid.NewGuid();
                _bookId2 = Guid.NewGuid();
                _store = A.Fake<IStore>();

                _booksList = new List<Book>
                    {
                        new Book {Id = _bookId1, Author = "Author", ISBN = "ISBN", Title = "Title"},
                        new Book {Id = _bookId2, Author = "Author 2", ISBN = "ISBN 2", Title = "Title 2"}
                    };

                A.CallTo(() => _store.GetAllBooks()).Returns(_booksList);

                _repository = new Repository(_store);
            };

        private Because of = () =>
            {
                _books = _repository.GetAllBooks();
            };

        private It the_returned_books_list_should_be_greater_than_zero = () => _books.Count().ShouldBeGreaterThan(0);
        private It the_id_of_the_first_element_in_the_book_list_should_equal_bookId1 = () => _books.SingleOrDefault(b => b.Id == _bookId1).Id.ShouldEqual(_bookId1);
        private It the_id_of_the_second_element_in_the_book_list_should_equal_bookId2 = () => _books.SingleOrDefault(b => b.Id == _bookId2).Id.ShouldEqual(_bookId2);
        private It a_call_to_store_GetAllBooks_should_happen = () => A.CallTo(() => _store.GetAllBooks()).MustHaveHappened();
    }
}
