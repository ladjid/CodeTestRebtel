using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_retrieving_all_books_from_an_empty_book_list
    {
        private static Store _store;
        private static IEnumerable<Book> _booksList;

        private Establish context = () =>
        {
            _store = new Store(true);
        };

        private Because of = () =>
        {
            _booksList = _store.GetAllBooks();
        };

        private It _books_list_count_should_be_zero = () => _booksList.Count().ShouldEqual(0);
    }
}
