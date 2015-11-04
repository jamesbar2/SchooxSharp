using System.Collections.Generic;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class NewUnit
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("above_ids")]
        public List<int> AboveIds { get; set; }

        [JsonProperty("jobs")]
        public List<Job> Jobs { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, AboveIds: {2}, Jobs: {3}", Id, Name, AboveIds, Jobs);
        }
    }
}