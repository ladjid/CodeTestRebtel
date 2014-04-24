using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Contracts;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;
using FakeItEasy;

namespace CodeTestRebtel.Data.Tests.RepositoryTest
{
    class when_retrieving_all_books_from_an_empty_book_list
    {
        private static IStore _store;
        private static Repository _repository;
        private static IEnumerable<Book> _books;

        private Establish context = () =>
            {
                _store = A.Fake<IStore>();
                var booklist = new List<Book>();
                A.CallTo(() => _store.GetAllBooks()).Returns(booklist);
                _repository = new Repository(_store);
            };

        private Because of = () =>
            {
                _books = _repository.GetAllBooks();
            };

        private It book_list_count_should_be_zero = () => _books.Count().ShouldEqual(0);
        private It a_call_to_store_GetAllBooks_should_happen = () => A.CallTo(() => _store.GetAllBooks()).MustHaveHappened();
    }
}
