using System.Collections.Generic;
using OAuthTwitterWrapper.JsonTypes;

namespace OAuthTwitterWrapper
{
    public interface ISearchResult
    {
        string SearchText { get; set; }
        Search Search { get; set; }
        List<KeyValuePair<string, int>> CountedTweets { get; set; }
    }
}
