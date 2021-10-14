using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Library.Models;
using Library.Helpers;

namespace Library.DAL
{
    public class BookService : IBookService
    {
        // Get data context - DI to separate concerns - could even change to DB later

        //TODO - The ApiController will use this class

        // Should we have a DI container in Global.asax and put the BookService there so that 
        // it doesn't need to get called in the ApiController(s)?

        // CHECK - whats the quickest way to read and search? FileStrem?

        //private string bookStore = @"C:\test\LibrarySample\LibrarySample-master\Resources";

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
                            "*",
                            "(",
                            ")",
                            "[",
                            "]",
                            "#"
                          };

        private List<string> GetBookTitles(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            List<string> bookTitles = new List<string>();
            foreach(string file in files)
            {
                bookTitles.Add(Path.GetFileNameWithoutExtension(file));
            }
            return bookTitles;

        }

        //TODO - SOrt this!!!
        string IBookService.SearchBook(int Id)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, int> GetSearchResults(string[] wordsToSearch)
        //  static List<string> GetSerachresults(string[] wordsToSearch)
        {
            Dictionary<string, int> searchResults = new Dictionary<string, int>();

            string searchTerm = "the";

            //var matchQuery = from word in wordsToSearch
            //                     //where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
            //                 where word.ToLowerInvariant().StartsWith(searchTerm.ToLowerInvariant())
            //                 orderby word.Length descending
            //                 select word;

            var matchQuery = from word in wordsToSearch
                             where word.ToLowerInvariant().StartsWith(searchTerm.ToLowerInvariant())
                             //orderby word.Length descending
                             group word by word
                             into grp
                             select new
                             {
                                 Word = grp.Key,
                                 Count = grp.Select(w => w).Count()
                             };
            var matchQueryOrdered = matchQuery.OrderByDescending(m => m.Count).ToDictionary(p => p.Word, p => p.Count);
            int wordCount = matchQuery.Count();

            int i = 0;
            foreach(var m in matchQueryOrdered)
            {
                Console.WriteLine($"{i} : {m.Key}, {m.Value}");
                i++;
            }
            return (Dictionary<string, int>)matchQueryOrdered;
        }


        public Dictionary<string, int> SearchBook(int id, string searchString = "", int numberOfCharsSearchTrigger = 3, int numnberOfRecordsReturned = 10, int minWordLengthToReturn = 5)
        {

            //TODO -try to get from the Memroy Cache at this point.
            // if null then do the below and populate the cache
            Book book = GetBooks(id);
            Dictionary<string, int> searchResults = new Dictionary<string, int>();
            try
            {
                // Open the text file using a stream reader.
                using(var sr = new StreamReader(
                            ConfigurationSettings.GetSetting("bookStorePath") + book.FileName,
                            System.Text.Encoding.UTF8))
                {
                    // TODO put into Helpers.StringFunctions
                    // public string[] strings GetStringArray(StreamReader streamReader)
                    string content = sr.ReadToEnd();

                    //split into word array
                    string[] words = content.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                    searchResults = GetSearchResults(words);

                    // HOW FAST IS THIS?? CAN WE MOVE IT DOWNSTREAM??
                    // 
                    // YES - PERFORMANCE IS ABOVE MEMORY
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




        //public List<string> Search(string searchString)
        //{
        //    //TODO - is it faster to use an array?
        //    List<string> searchResults = new List<string>();
        //    try
        //    {
        //        // Open the text file using a stream reader.
        //        using(var sr = new StreamReader("TestFile.txt"))
        //        {
        //            // Read the stream as a string, and write the string to the console.
        //            Console.WriteLine(sr.ReadToEnd());
        //        }
        //    }
        //    catch(IOException e)
        //    {
        //        //Console.WriteLine("The file could not be read:");
        //        //Console.WriteLine(e.Message);
        //    }
        //return searchResults;
        //}
    }
}