using System;
using System.Collections.Generic;
using CodeTestRebtel.Data.Contracts;
using CodeTestRebtel.Data.Models;

namespace CodeTestRebtel.Data.Services
{
    public class Repository : IBookShelf
    {
        public IStore Store;

        public Repository(IStore store)
        {
            Store = store;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return Store.GetAllBooks();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Store.GetAllUsers();
        }

        public bool Loan(Guid bookId, Guid userId)
        {
            return Store.Loan(bookId, userId);
        }

        public bool Return(Guid bookId, Guid userId)
        {
            return Store.Return(bookId, userId);
        }
    }
}
