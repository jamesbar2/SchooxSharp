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

        public override string ToString()
        {
            return string.Format("Id: {0}, Title: {1}, Time: {2}, Progress: {3}", Id, Title, Time, Progress);
        }
    }
}
