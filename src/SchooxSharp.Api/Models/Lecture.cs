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

        public override string ToString()
        {
            return string.Format("Id: {0}, Title: {1}, Progress: {2}, Time: {3}", Id, Title, Progress, Time);
        }
    }
}
