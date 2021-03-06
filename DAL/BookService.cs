using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Library.Models;
using Library.Helpers;
using Library.SearchService;

namespace Library.DAL
{
    public class BookService : IBookService
    {
        
        //public delegate List<WordItem> ProcessWords(List<WordItem> words);
        //ProcessWords wordArray = CaptialiseFirstLetter;

        //TODO - put in separate class and make public accessor
        public static List<WordItem> CaptialiseFirstLetter(List<WordItem> words)
        {
            for(int i = 0; i < words.Count; i++)
            {
                words[i].Word = char.ToUpper(words[i].Word[0]) + words[i].Word.Substring(1);
            }
            return words;
        }

        private List<Book> books = new List<Book>();

        private BookContext bookContext = new BookContext();

        private string bookTitle = String.Empty;

        // TODO - Put this in config for example
        string[] delimiterChars = {
                            " ",
                            "\r\n",
                            "\t",
                            "\n",
                            ".",
                            ",",
                            ":",
                            ";",
                            "!",
                            "?",
                            "*",
                            "(",
                            ")",
                            "[",
                            "]",
                            "<",
                            ">",
                            "#",
                            "-",
                            "_",
                            "—",
                            "\\",
                            "/",
                            "\"",
                            "”",
                            "'",
                            "’"
                          };


        //TODO move to another file
        public static string[] StandardiseCase(string[] words)
        {
            for(int i=0; i<words.Length;i++)
            {
                words[i] = words[i].ToLowerInvariant();
            }
            return words;
        }

        //public delegate List<WordItem> PerformSearch(string[] wordsToSearch, string searchString);

        public List<WordItem> SearchBook(int id, string searchString = "")
        {

            //TODO -try to get from the Memroy Cache at this point.
            // if null then do the below and populate the cache
            Book book = GetBooks(id);
            List<WordItem> searchResults = new List<WordItem>();
            try
            {
                // Open the text file using a stream reader.
                using(var sr = new StreamReader(
                            ConfigurationSettings.GetSetting("bookStorePath") + book.FileName,
                            System.Text.Encoding.UTF8))
                {
                    string content = sr.ReadToEnd();

                    //split into word array
                    string[] words = content.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                    words = StandardiseCase(words);

                    // ***
                    // TODO - Cache "words" string array here for re-use
                    // ***

                    searchResults = Search.GetResults(words, searchString);

                    searchResults = CaptialiseFirstLetter(searchResults);

                    // HOW FAST IS THIS?? CAN WE MOVE IT DOWNSTREAM??
                    // 
                    // YES - it's asked for PERFORMANCE IS ABOVE MEMORY
                    // Use MemoryCache
                    // https://docs.microsoft.com/en-us/dotnet/api/system.runtime.caching.memorycache?view=netframework-4.5
                    // you need to store the word and the count - could you use HashSet<string, int>
                    // Or could we split into an array of words, remove hyphens etc and then do Regex?


                }
            }
            // if we need to do different things depending on the type of exception
            // otherwise can just catch the general one.
            catch(FileNotFoundException f)
            {
                Console.WriteLine("FileNotFoundException");
            }
            catch(IOException e)
            {
                Console.WriteLine("The file could not be read:");
                //Console.WriteLine(e.Message);
            }
            catch(OutOfMemoryException o)
            {
                Console.WriteLine("OutOfMemoryException");
            }

            return searchResults;
        }


        // TODO Have an overload for GetBooks with
        // a) the number of chars to trigger the search 
        // b) the number of results to return
        // c) orderby
        public Book GetBooks(int id)
        {
            //TODO - Have this call to a cache for each book.
            // If it's empty then that's when you make the call to the DB to retrieve the result
            Book book = bookContext.GetBooks(id).SingleOrDefault();
            return book;
        }

        public List<Book> GetBooks()
        {
            List<Book> book = bookContext.GetBooks();
            return book;
        }
    }
}