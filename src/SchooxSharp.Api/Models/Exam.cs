using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Exam
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        [JsonProperty("attempts")]
        public int Attempts { get; set; }

        [JsonProperty("last_attempt")]
        public LastAttemptObject LastAttempt { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("points")]
        public PointsScore Points { get; set; }

        [JsonProperty("passed")]
        public bool Passed { get; set; }

        public class LastAttemptObject
        {
            [JsonProperty("date_start")]
            public string DateStart { get; set; }

            [JsonProperty("date_end")]
            public string DateEnd { get; set; }
        }

    }

}
