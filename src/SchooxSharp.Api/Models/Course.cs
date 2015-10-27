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
        public int? Students { get; set; }

        [JsonProperty("completion_rate")]
        public int? CompletionRate { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("progress")]
        public int? Progress { get; set; }

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

        //Added from list_courses
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("instructor")]
        public User Instructor { get; set; }

        [JsonProperty("lectures")]
        public int? Lectures { get; set; }

        [JsonProperty("exams")]
        public int? Exams { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("category")]
        public CourseCategory Category { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("price")]
        public int? Price { get; set; }

        [JsonProperty("academy_id")]
        public int? AcademyId { get; set; }

        [JsonProperty("priority")]
        public int? Priority { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("timecompleted")]
        public string Timecompleted { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("time_published")]
        public string TimePublished { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Title: {1}, Image: {2}, Students: {3}, CompletionRate: {4}, PublishDate: {5}, Url: {6}, Progress: {7}, TotalTime: {8}, EnrollDate: {9}, Certificates: {10}, DueDate: {11}, IsDue: {12}, Description: {13}, Instructor: {14}, Lectures: {15}, Exams: {16}, Level: {17}, Category: {18}, Tags: {19}, Price: {20}, AcademyId: {21}, Priority: {22}, Role: {23}, Timecompleted: {24}, Time: {25}, TimePublished: {26}, Scope: {27}",
                    Id, Title, Image, Students, CompletionRate, PublishDate, Url, Progress, TotalTime, EnrollDate,
                    Certificates, DueDate, IsDue, Description, Instructor, Lectures, Exams, Level, Category, Tags, Price,
                    AcademyId, Priority, Role, Timecompleted, Time, TimePublished, Scope);
        }
    }

}
