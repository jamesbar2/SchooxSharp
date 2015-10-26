using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Lecture
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

    }
}
