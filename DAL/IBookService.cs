using Library.Models;
using System.Collections.Generic;

namespace Library.DAL
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBooks(int Id);
        List<WordItem> SearchBook(int id, string searchString = "");
    }
}