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

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("total_course_hours")]
        public string TotalCourseHours { get; set; }

        [JsonProperty("total_courses")]
        public int TotalCourses { get; set; }

        [JsonProperty("total_exams")]
        public int TotalExams { get; set; }

        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("enrolment_date")]
        public string EnrollmentDate { get; set; }

    }

}
