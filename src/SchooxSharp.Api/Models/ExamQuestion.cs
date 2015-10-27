using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class ExamQuestion
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("correct")]
        public bool Correct { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}, Correct: {1}", Title, Correct);
        }
    }
}