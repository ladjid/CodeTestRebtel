using System;
using System.Collections.Generic;
using CodeTestRebtel.Data.Models;

namespace CodeTestRebtel.Data.Contracts
{
    public interface IStore
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<User> GetAllUsers();
        bool Loan(Guid bookId, Guid userId);
        bool Return(Guid bookId, Guid userId);
    }
}
