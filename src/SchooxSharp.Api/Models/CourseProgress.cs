using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class CourseProgress
    {
        [JsonProperty("lectures")]
        public List<Lecture> Lectures { get; set; }

        [JsonProperty("exams")]
        public List<Exam> Exams { get; set; }

        [JsonProperty("certificates")]
        public List<Certificate> Certificates { get; set; }

        public override string ToString()
        {
            return string.Format("Lectures: {0}, Exams: {1}, Certificates: {2}", Lectures, Exams, Certificates);
        }
    }

}
