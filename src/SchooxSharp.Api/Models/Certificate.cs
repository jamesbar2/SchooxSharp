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

        public override string ToString()
        {
            return string.Format("Id: {0}, VerCode: {1}, TotalTime: {2}, TimeCertified: {3}, Url: {4}", Id, VerCode,
                TotalTime, TimeCertified, Url);
        }
    }
}
