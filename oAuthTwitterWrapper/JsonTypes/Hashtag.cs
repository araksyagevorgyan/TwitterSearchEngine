using System.Collections.Generic;
using Newtonsoft.Json;

namespace OAuthTwitterWrapper.JsonTypes
{

    public class Hashtag
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("indices")]
        public List<int> Indices { get; set; }

    }

}
