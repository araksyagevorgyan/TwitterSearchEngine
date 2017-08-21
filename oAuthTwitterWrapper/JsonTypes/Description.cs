using System.Collections.Generic;
using Newtonsoft.Json;

namespace OAuthTwitterWrapper.JsonTypes
{

    public class Description
    {		
        [JsonProperty("urls")]
		public List<Url> Urls { get; set; }
    }

}
