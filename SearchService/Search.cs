using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.SearchService
{
    public static class Search
    {
        public static List<WordItem> GetResults(string[] wordsToSearch, string searchString = "")
        {
            ISearchService searchService; 
            if(String.IsNullOrWhiteSpace(searchString))
            {
                searchService = new DefaultSearchService();
            }
            else
            {
                searchService = new QueryableSearchService();
            }
            return searchService.GetSearchResults(wordsToSearch, searchString);
        }

    }
}