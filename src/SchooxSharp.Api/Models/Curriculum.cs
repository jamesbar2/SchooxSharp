using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Curriculum
    {    
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("progress")]
        public int? Progress { get; set; }

        [JsonProperty("total_time")]
        public string TotalTime { get; set; }

        [JsonProperty("enroll_date")]
        public string EnrollDate { get; set; }

        [JsonProperty("students")]
        public int? Students { get; set; }

        [JsonProperty("completion_rate")]
        public int? CompletionRate { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        //Added for Curriculum 
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("private")]
        public bool? Private { get; set; }

        [JsonProperty("enrolled")]
        public bool? Enrolled { get; set; }

        //BUG: Can either be an integer or a List<Courses>
        [JsonProperty("courses")]
        public object Courses { get; set; }

        [JsonProperty("time_spent")]
        public string TimeSpent { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Title: {1}, Image: {2}, Url: {3}, Progress: {4}, TotalTime: {5}, EnrollDate: {6}, Students: {7}, CompletionRate: {8}, PublishDate: {9}, Description: {10}, Private: {11}, Enrolled: {12}, Courses: {13}, TimeSpent: {14}",
                    Id, Title, Image, Url, Progress, TotalTime, EnrollDate, Students, CompletionRate, PublishDate,
                    Description, Private, Enrolled, Courses, TimeSpent);
        }
    }

}
