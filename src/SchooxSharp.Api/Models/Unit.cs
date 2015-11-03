using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Unit
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("above_ids")]
        public List<int> AboveIds { get; set; }
        
        [JsonProperty("jobs")]
        public List<Job> Jobs { get; set; }
    }

}
