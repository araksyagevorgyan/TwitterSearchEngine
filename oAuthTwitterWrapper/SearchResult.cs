using OAuthTwitterWrapper.JsonTypes;
using System.Collections.Generic;

namespace OAuthTwitterWrapper
{
    public class SearchResult : ISearchResult
    {
        public string SearchText { get; set; }
        public Search Search { get; set; }
        public List<KeyValuePair<string, int>> CountedTweets
        {
            get; set;
        }
    }
}
