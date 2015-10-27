using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class User
    {
     
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        //TODO: Check why this was serialized as an object by the converter
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("total_course_hours")]
        public string TotalCourseHours { get; set; }

        [JsonProperty("total_courses")]
        public int? TotalCourses { get; set; }

        [JsonProperty("total_exams")]
        public int? TotalExams { get; set; }

        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        [JsonProperty("progress")]
        public int? Progress { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("enrolment_date")]
        public string EnrollmentDate { get; set; }

        [JsonProperty("attempts")]
        public int? Attempts { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Firstname: {1}, Lastname: {2}, Email: {3}, Image: {4}, Url: {5}, TotalCourseHours: {6}, TotalCourses: {7}, TotalExams: {8}, DueDate: {9}, Progress: {10}, Time: {11}, EnrollmentDate: {12}, Attempts: {13}",
                    Id, Firstname, Lastname, Email, Image, Url, TotalCourseHours, TotalCourses, TotalExams, DueDate,
                    Progress, Time, EnrollmentDate, Attempts);
        }
    }

        
   

}
