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
        public int? Progress { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        //added for /courses/:courseid/lectures
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("demo")]
        public bool? Demo { get; set; }

        [JsonProperty("visible")]
        public bool? Visible { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Title: {1}, Progress: {2}, Time: {3}, Name: {4}, Description: {5}, Image: {6}, Url: {7}, Demo: {8}, Visible: {9}, Type: {10}",
                    Id, Title, Progress, Time, Name, Description, Image, Url, Demo, Visible, Type);
        }
    }
}
