using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Models;
using CodeTestRebtel.Data.Services;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.StoreTest
{
    class when_retrieving_all_books
    {
        private static Store _store;
        private static IEnumerable<Book> _booksList;

        private Establish context = () =>
            {
                _store = new Store();
            };

        private Because of = () =>
            {
                _booksList = _store.GetAllBooks();
            };

        private It _books_list_count_should_be_greater_than_zero = () => _booksList.Count().ShouldBeGreaterThan(0);
    }
}
