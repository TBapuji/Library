using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.SearchService
{
    interface ISearchService
    {
        List<WordItem> GetSearchResults(string[] wordsToSearch, string searchString = "");
    }
}
