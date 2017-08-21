using OAuthTwitterWrapper.JsonTypes;
using System.Collections.Generic;

namespace OAuthTwitterWrapper
{
	public interface IOAuthTwitterWrapper
	{
		string GetSearch();
        ISearchSettings SearchSettings { get; set; }
        List<KeyValuePair<string, int>> GetTopAppeardHashtags(Search search);
    }
}
