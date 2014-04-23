using System;
using System.Collections.Generic;
using CodeTestRebtel.Data.Models;

namespace CodeTestRebtel.Data.Contracts
{
    public interface IStore
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(Guid bookId);
        bool Loan(Guid bookId, Guid userId);
        bool Return(Guid bookId, Guid userId);
    }
}
