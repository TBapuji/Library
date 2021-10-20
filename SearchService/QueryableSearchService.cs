using Library.Models;
using System;
using System.Collections.Generic;
using Library.Helpers;
using System.Linq;
using System.Web;

namespace Library.SearchService
{
    public class QueryableSearchService : ISearchService
    {
        public List<WordItem> GetSearchResults(string[] wordsToSearch, string searchString = "")
        {
            List<WordItem> searchResults = new List<WordItem>();

            var matchQuery = from word in wordsToSearch
                             where word.ToLowerInvariant().StartsWith(searchString.ToLowerInvariant())
                             group word by word
                             into grp
                             select new WordItem
                             {
                                 Word = grp.Key,
                                 Count = grp.Select(w => w).Count()
                             };

            var matchQueryOrdered = matchQuery.OrderByDescending(m => m.Count);

            return matchQueryOrdered.ToList();
        }
    }
}