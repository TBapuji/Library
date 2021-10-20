using Library.Models;
using System.Collections.Generic;

namespace Library.DAL
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBooks(int Id);
        List<WordItem> SearchBook(int id, string searchString = "", int numberOfCharsSearchTrigger = 0, int numnberOfRecordsReturned = 0, int minWordLengthToReturn = 0);
    }
}