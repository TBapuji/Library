using Library.Models;
using System.Collections.Generic;

namespace Library.DAL
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBooks(int Id);
        string SearchBook(int Id);
    }
}