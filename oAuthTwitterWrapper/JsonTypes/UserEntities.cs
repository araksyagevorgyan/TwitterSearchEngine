using Newtonsoft.Json;

namespace OAuthTwitterWrapper.JsonTypes
{

    public class UserEntities
    {

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

}
