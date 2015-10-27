using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class CourseCategory
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", Id, Name);
        }
    }
}