using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    /// <summary>
    /// Base exam class to be shared since there's quirky object mixing
    /// </summary>
    public abstract class BaseExam
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

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("points")]
        public PointsScore Points { get; set; }

        [JsonProperty("passed")]
        public bool Passed { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("students")]
        public int? Students { get; set; }

        [JsonProperty("success_rate")]
        public int? SuccessRate { get; set; }

        [JsonProperty("average_score")]
        public int? AverageScore { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Name: {1}, Description: {2}, Image: {3}, Instructions: {4}, Attempts: {5}, Points: {6}, Score: {7}, Passed: {8}, Title: {9}, Students: {10}, SuccessRate: {11}, AverageScore: {12}",
                    Id, Name, Description, Image, Instructions, Attempts, Points, Score, Passed, Title, Students,
                    SuccessRate, AverageScore);
        }
    }

    /// <summary>
    /// What most exams will use, the Last Attempt is sent a single date/time.
    /// </summary>
    public class Exam : BaseExam
    {
        [JsonProperty("last_attempt")]
        public string LastAttempt { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, LastAttempt: {1}", base.ToString(), LastAttempt);
        }
    }

    /// <summary>
    /// What GET /dashboard/users/:userid/exams uses since it sends a complex object back instead of a single date time
    /// </summary>
    public class UsersExam : BaseExam
    {
        [JsonProperty("last_attempt")]
        public LastAttemptObject LastAttempt { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, LastAttempt: {1}", base.ToString(), LastAttempt);
        }

        public class LastAttemptObject
        {
            [JsonProperty("date_start")]
            public string DateStart { get; set; }

            [JsonProperty("date_end")]
            public string DateEnd { get; set; }

            public override string ToString()
            {
                return string.Format("DateStart: {0}, DateEnd: {1}", DateStart, DateEnd);
            }
        }
    }

}
