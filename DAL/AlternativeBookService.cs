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

        List<Book> IBookService.GetBooks()
        {
            throw new NotImplementedException();
        }

        Book IBookService.GetBooks(int Id)
        {
            throw new NotImplementedException();
        }

        List<WordItem> IBookService.SearchBook(int id, string searchString)
        {
            throw new NotImplementedException();
        }
    }
}