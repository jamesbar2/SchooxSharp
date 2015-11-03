using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class ExamPerformance
    {

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("passing_score")]
        public int PassingScore { get; set; }

        [JsonProperty("passing_points")]
        public int PassingPoints { get; set; }

        [JsonProperty("passed")]
        public bool Passed { get; set; }

        [JsonProperty("questions")]
        public List<ExamQuestion> Questions { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Score: {0}, Points: {1}, PassingScore: {2}, PassingPoints: {3}, Passed: {4}, Questions: {5}", Score,
                    Points, PassingScore, PassingPoints, Passed, Questions);
        }
    }
}
