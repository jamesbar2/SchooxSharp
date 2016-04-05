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

        [JsonProperty("username")]
        public string UserId { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }
        
        [JsonProperty("password")]		
        public string Password { get; set; }

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

        [JsonProperty("enrolment_date")]    //not a typo, there's a typo inside the Schoox API
        public string EnrollmentDate { get; set; }

        [JsonProperty("attempts")]
        public int? Attempts { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("units")]
        public List<Unit> Units { get; set; }

        [JsonProperty("certificates")]
        public List<Certificate> Certificates { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, UserId: {1}, FirstName: {2}, LastName: {3}, Password: {4}, Email: {5}, Image: {6}, Url: {7}, TotalCourseHours: {8}, TotalCourses: {9}, TotalExams: {10}, DueDate: {11}, Progress: {12}, Time: {13}, EnrollmentDate: {14}, Attempts: {15}, ProfileUrl: {16}, Active: {17}, Roles: {18}, Units: {19}, Certificates: {20}",
                    Id, UserId, FirstName, LastName, Password, Email, Image, Url, TotalCourseHours, TotalCourses,
                    TotalExams, DueDate, Progress, Time, EnrollmentDate, Attempts, ProfileUrl, Active, Roles, Units,
                    Certificates);
        }
    }

}


