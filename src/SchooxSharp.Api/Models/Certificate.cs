using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Certificate
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ver_code")]
        public string VerCode { get; set; }

        [JsonProperty("total_time")]
        public int TotalTime { get; set; }

        [JsonProperty("time_certified")]
        public string TimeCertified { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
