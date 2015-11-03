using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{

    public class AboveUnit
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type_id")]
        public int TypeId { get; set; }
    }

}
