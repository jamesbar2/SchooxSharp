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

        //added for /courses/:courseid/exams
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_limit")]
        public string TimeLimit { get; set; }

        [JsonProperty("lecture_id")]
        public int LectureId { get; set; }

        [JsonProperty("time_added")]
        public string TimeAdded { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        [JsonProperty("creator")]
        public User Creator { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Name: {1}, Description: {2}, Image: {3}, Instructions: {4}, Attempts: {5}, Score: {6}, Points: {7}, Passed: {8}, Title: {9}, Students: {10}, SuccessRate: {11}, AverageScore: {12}, Url: {13}, Type: {14}, TimeLimit: {15}, LectureId: {16}, TimeAdded: {17}, Published: {18}, Disabled: {19}, Creator: {20}",
                    Id, Name, Description, Image, Instructions, Attempts, Score, Points, Passed, Title, Students,
                    SuccessRate, AverageScore, Url, Type, TimeLimit, LectureId, TimeAdded, Published, Disabled, Creator);
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
