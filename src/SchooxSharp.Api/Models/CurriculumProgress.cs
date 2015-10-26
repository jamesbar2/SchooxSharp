using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class CurriculumProgress
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }
    }
}
