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
                var user = new User {Id = Guid.NewGuid(), Firstname = "Surename" + i, Lastname = "Lastname" + i, BooksBorrowed = new List<Guid>()};
                Users.Add(user);
            }

            for (var i = 0; i < 20; i++)
            {
                var books = new Book { Id = Guid.NewGuid(), Author = "Author " + i, ISBN = "ISBN " + i, Title = "Title " + i };
                Books.Add(books);
            }
        }

        public Store(bool instantiateWithoutFillingLists){}
        
        public IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        public bool Loan(Guid bookId, Guid userId)
        {
            try
            {
                var bookss = Books;
                var book = Books.SingleOrDefault(b => b.Id == bookId);

                if (book.LoanedTo != null)
                {
                    return false;
                }

                var user = Users.SingleOrDefault(u => u.Id == userId);
                book.LoanedTo = user.Id;
                book.LoanedToName = user.Firstname + " " + user.Lastname;
                user.BooksBorrowed.Add(book.Id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Return(Guid bookId, Guid userId)
        {
            try
            {
                var book = Books.SingleOrDefault(b => b.Id == bookId);

                if (book.LoanedTo == null)
                {
                    return false;
                }

                var user = Users.SingleOrDefault(u => u.Id == userId);
                book.LoanedTo = null;
                book.LoanedToName = string.Empty;
                user.BooksBorrowed.Remove(book.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
