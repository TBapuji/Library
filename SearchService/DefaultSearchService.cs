using Library.Helpers;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.SearchService
{
    public class DefaultSearchService : ISearchService
    {
        private string[] _wordsToSearch = new string[] { };
        private string _searchString = "";

        //public DefaultSearchService(string[] wordsToSearch, string searchString = "")
        //{
        //    _wordsToSearch = wordsToSearch;
        //    _searchString = searchString;
        //}

        string minWordLengthToReturnString = ConfigurationSettings.GetSetting("minWordLengthToReturn");

        string numnberOfWordsReturnedString = ConfigurationSettings.GetSetting("numnberOfWordsReturned");



        // TODO Make input params into a single object SearchParameters
        public List<WordItem> GetSearchResults(string[] wordsToSearch, string searchString = "")
        {
            List<WordItem> searchResults = new List<WordItem>();

            int.TryParse(minWordLengthToReturnString, out int minWordLengthToReturn);

            int.TryParse(numnberOfWordsReturnedString, out int numnberOfWordsReturned);

            var matchQuery2 = (from word in wordsToSearch
                               where word.Length >= minWordLengthToReturn
                               group word by word
                                          into grp
                               orderby grp.Count() descending
                               select new WordItem
                               {
                                   Word = grp.Key,
                                   Count = grp.Select(w => w).Count()
                               });
            // .Take(10); -> causes a conversion exception here
            var ordered = matchQuery2.OrderByDescending(m => m.Count).Take(numnberOfWordsReturned);

            return ordered.ToList();

        }


    }
}