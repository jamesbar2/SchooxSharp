using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Job
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("deletable")]
        public bool? Deletable { get; set; }

        [JsonProperty("report_id")]
        public int? ReportId { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Deletable: {2}, ReportId: {3}", Id, Name, Deletable, ReportId);
        }
    }
}