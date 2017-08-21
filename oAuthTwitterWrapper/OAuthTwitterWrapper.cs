using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using OAuthTwitterWrapper.JsonTypes;

namespace OAuthTwitterWrapper
{
	public class OAuthTwitterWrapper : IOAuthTwitterWrapper
    {
		public IAuthenticateSettings AuthenticateSettings { get; set; }
		public ISearchSettings SearchSettings { get; set; }

    /// <summary>
    /// The default constructor takes all the settings from the appsettings file
    /// </summary>
    public OAuthTwitterWrapper()
		{
			string oAuthConsumerKey = ConfigurationManager.AppSettings["oAuthConsumerKey"];
            string oAuthConsumerSecret = ConfigurationManager.AppSettings["oAuthConsumerSecret"];
            string oAuthUrl = ConfigurationManager.AppSettings["oAuthUrl"];
			AuthenticateSettings = new AuthenticateSettings { OAuthConsumerKey = oAuthConsumerKey, OAuthConsumerSecret = oAuthConsumerSecret, OAuthUrl = oAuthUrl };
			string screenname = ConfigurationManager.AppSettings["screenname"];
			string include_rts = ConfigurationManager.AppSettings["include_rts"];
			string exclude_replies = ConfigurationManager.AppSettings["exclude_replies"];
			int count = Convert.ToInt16(ConfigurationManager.AppSettings["count"]);
			string timelineFormat = ConfigurationManager.AppSettings["timelineFormat"];			
			
			string searchFormat = ConfigurationManager.AppSettings["searchFormat"];
            string searchQuery = "&count=100";

            SearchSettings = new SearchSettings
			{
				SearchFormat = searchFormat,
				SearchQuery = searchQuery
			};
				
		}

		/// <summary>
		/// This allows the authentications settings to be passed in
		/// </summary>
		/// <param name="authenticateSettings"></param>
		public OAuthTwitterWrapper(IAuthenticateSettings authenticateSettings)
		{
			AuthenticateSettings = authenticateSettings;
		}

		/// <summary>
		/// This allows the authentications, timeline and search settings to be passed in
		/// </summary>
		/// <param name="authenticateSettings"></param>
		/// <param name="timeLineSettings"></param>
		/// <param name="searchSettings"></param>
		public OAuthTwitterWrapper(IAuthenticateSettings authenticateSettings, ISearchSettings searchSettings)
		{
			AuthenticateSettings = authenticateSettings;
			SearchSettings = searchSettings;
		}

		public string GetSearch()
        {
            var searchJson = string.Empty;
			IAuthenticate authenticate = new Authenticate();
			AuthResponse twitAuthResponse = authenticate.AuthenticateMe(AuthenticateSettings);

            // Do the timeline
            var utility = new Utility();
			searchJson = utility.RequstJson(SearchSettings.SearchUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);

			return searchJson;
		}

        public List<KeyValuePair<string, int>> GetTopAppeardHashtags(Search search)
        {
            var hashtags = new List<Hashtag>();
            var countedHashtags = new Dictionary<string, int>();
            //foreach(var a in search.Results.Count
            foreach(var result in search.Results){
                foreach (var hashtag in result.entities.Hashtags)
                {
                    if (!countedHashtags.Keys.Contains(hashtag.Text))
                    {
                        countedHashtags.Add(hashtag.Text, 1);
                    } else
                    {
                        countedHashtags[hashtag.Text] += 1;
                    }
                }
            }
            var listTopHashtags = countedHashtags.OrderByDescending(s => s.Value).Take(10);
            return listTopHashtags.ToList();
        }
    }
}
