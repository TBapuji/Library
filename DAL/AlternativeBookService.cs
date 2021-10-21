using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.DAL
{
    public class AlternativeBookService : IBookService
    {
        public List<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBooks(int Id)
        {
            throw new NotImplementedException();
        }

        public List<WordItem> SearchBook(int id, string searchString)
        {
            throw new NotImplementedException();
        }
    }
}