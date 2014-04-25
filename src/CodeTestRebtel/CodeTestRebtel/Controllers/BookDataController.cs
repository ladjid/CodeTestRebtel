using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeTestRebtel.Data.Services;
using CodeTestRebtel.Data.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CodeTestRebtel.Controllers
{
    public class BookDataController : Controller
    {
        //
        // GET: /BookData/
        private readonly IBookShelf _repository;

        public BookDataController(IBookShelf repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ContentResult GetAllBooks()
        {
            return Content(JsonConvert.SerializeObject(_repository.GetAllBooks()));
        }

        [HttpGet]
        public ContentResult GetallUsers()
        {
            return Content(JsonConvert.SerializeObject(_repository.GetAllUsers()));
        }

        [HttpGet]
        public ContentResult Loan(Guid bookId, Guid userId)
        {
            return Content(JsonConvert.SerializeObject(_repository.Loan(bookId, userId)));
        }

        [HttpGet]
        public ContentResult Return(Guid bookId, Guid userId)
        {
            return Content(JsonConvert.SerializeObject(_repository.Return(bookId, userId)));
        }

        [HttpGet]
        public ContentResult FilterBooks(string filter)
        {
            var books = _repository.GetAllBooks();

            if (string.IsNullOrEmpty(filter))
            {
                return Content(JsonConvert.SerializeObject(books));
            }

            var filterBooks = books.Where(f => 
                    f.ISBN.ToLower().Contains(filter) ||
                    f.Title.ToLower().Contains(filter) || 
                    f.LoanedTo.HasValue && f.LoanedTo.Value.ToString().Contains(filter)||
                    f.Author.ToLower().Contains(filter) 
                    
             );

            return Content(JsonConvert.SerializeObject(filterBooks));
        }
    }
}
