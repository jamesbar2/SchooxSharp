using System.Collections.Generic;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Course
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("students")]
        public int Students { get; set; }

        [JsonProperty("completion_rate")]
        public int CompletionRate { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("total_time")]
        public string TotalTime { get; set; }

        [JsonProperty("enroll_date")]
        public string EnrollDate { get; set; }

        [JsonProperty("certificates")]
        public List<Certificate> Certificates { get; set; }

        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        [JsonProperty("is_due")]
        public bool IsDue { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Title: {1}, Image: {2}, Students: {3}, CompletionRate: {4}, PublishDate: {5}, Url: {6}, Progress: {7}, TotalTime: {8}, EnrollDate: {9}, Certificates: {10}, DueDate: {11}, IsDue: {12}",
                    Id, Title, Image, Students, CompletionRate, PublishDate, Url, Progress, TotalTime, EnrollDate,
                    Certificates, DueDate, IsDue);
        }
    }
}
