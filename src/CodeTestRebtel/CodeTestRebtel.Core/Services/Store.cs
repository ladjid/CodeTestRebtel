using System;
using System.Collections.Generic;
using System.Linq;
using CodeTestRebtel.Data.Contracts;
using CodeTestRebtel.Data.Models;

namespace CodeTestRebtel.Data.Services
{
    public class Store : IStore
    {
        public List<User> Users = new List<User>(); 
        public List<Book> Books = new List<Book>(); 

        public Store()
        {
            for (var i = 0; i < 10; i++)
            {
                var user = new User {Id = Guid.NewGuid(), Firstname = "User " + i, Lastname = "User Lastname" + i};
                Users.Add(user);
            }

            for (var i = 0; i < 20; i++)
            {
                var books = new Book { Id = Guid.NewGuid(), Author = "Author " + i, ISBN = "ISBN " + i, Title = "Title " + i };
                Books.Add(books);
            }
        }
        
        public IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }

        public Book GetBookById(Guid bookId)
        {
            return Books.SingleOrDefault(b => b.Id == bookId);
        }

        public bool Loan(Guid bookId, Guid userId)
        {
            try
            {
                var book = Books.SingleOrDefault(b => b.Id == bookId);
                var user = Users.SingleOrDefault(u => u.Id == userId);
                book.LoanedTo = user;
                user.BooksBorrowed.Add(book);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Return(Guid bookId, Guid userId)
        {
            try
            {
                var book = Books.SingleOrDefault(b => b.Id == bookId);
                var user = Users.SingleOrDefault(u => u.Id == userId);
                book.LoanedTo = null;
                user.BooksBorrowed.Remove(book);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
