using Library.DAL;
using Library.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Library.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {

        // TODO - use DI so you don't have to declare here
        //private IBookService bookService = new BookService();
        private BookService bookService = new BookService();

        [HttpGet]
        public List<Book> Get()
        {
            return bookService.GetBooks();
        }


        //TODO - if we pass in extra params in signature with default web config values
        // can we avoid the need 
        // SE TINN C - WHAT ARE THE NAMES FOR THERES
        //[Route("api/books/{Id}")]
        [Route("{Id}")]
        [HttpGet]
        public Book Books(int id)
        {
            return bookService.GetBooks(id);
        }

        //[Route("api/books/{Id}?query={query}")]
        //[Route("/{Id}?query={query}")]
        [HttpGet]
        public Dictionary<string,int> SearchBook(int id, string query)
        {
            return bookService.SearchBook(id, query);
        }
        /*
        The following GET methods are expected on the api/books controller:

            1. GET api/books
                Returns a list of Ids & Titles for all the books in the Resources folder
                Titles should be the name of the filename, minus the extension.
                The Id should be unique.


         ***  HOW TO GET THE ID OF A BOOK WHEN IT'S JUST A FILE?? ***


            2. GET api/books/{Id}
                Returns a list of the most common 10 words (min 5 letters) and how many times they occur in the specified book.
                When parsing, whitespace, linefeeds and punctiation should be ignored, and words matched case-insensitively (e.g. "the" and "The" and "THE" will be returned as "The"=3)
                Words should be returned in capital case (e.g. Word), and the list should be sorted in decreasing incidence.


        *** ONKEY UP in js fetch would call this action method ***


            3. GET api/books/{Id}?query={query}
                Returns a list of all words which start with the specified string (min 3 letters) and the number of times they occur within the specified book.
                Case matching should be insensitive.

        The logic for these calls should largely be encapsulated in other classes. This should make it easier to Unit Test those classes
        to validate the expected behaviour.
        */
    }
}
