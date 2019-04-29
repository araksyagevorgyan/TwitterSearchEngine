using System.Web.Mvc;
using Newtonsoft.Json;
using OAuthTwitterWrapper;
using OAuthTwitterWrapper.JsonTypes;
using System.Web.Http;
using System.Configuration;
using System.Collections.Generic;
using System;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private IOAuthTwitterWrapper _oAuthTwitterWrapper;

        public HomeController()
        {
            _oAuthTwitterWrapper = new OAuthTwitterWrapper.OAuthTwitterWrapper();
        }
        
        public ActionResult SearchTweets(SearchResult searchResult)
        {
            ModelState.Clear();
            if (Session["SearchResult"] != null)
            {
                searchResult = (SearchResult)Session["SearchResult"];
            }
            return View(searchResult);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Tweets([FromBody]string search_terms)
        {
            var searchResult = new SearchResult();
            var searchText = String.IsNullOrEmpty(search_terms) ? ConfigurationManager.AppSettings["searchQuery"] : search_terms;
            _oAuthTwitterWrapper.SearchSettings.SearchFormat = string.Format(_oAuthTwitterWrapper.SearchSettings.SearchFormat, searchText);
            var json = _oAuthTwitterWrapper.GetSearch();
            var results = JsonConvert.DeserializeObject<Search>(json);

            var countedTweets =_oAuthTwitterWrapper.GetTopAppeardHashtags(results);
            if(search_terms != null)
            {
                searchResult.SearchText = search_terms;
                searchResult.Search = results;
                searchResult.CountedTweets = countedTweets;
            } else
            {
                searchResult.Search = new Search();
                searchResult.CountedTweets = new List<KeyValuePair<string, int>>();
            }
           
            Session["SearchResult"] = searchResult;
            return RedirectToAction("SearchTweets", "Home");
        }

    }
}
