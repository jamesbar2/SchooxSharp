using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Coupon
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("discount")]
        public int Discount { get; set; }

        [JsonProperty("quota")]
        public int Quota { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("time_created")]
        public string TimeCreated { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("max_quota")]
        public int? MaxQuota { get; set; }

        [JsonProperty("academy_id")]
        public int? AcademyId { get; set; }

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonProperty("time_accepted")]
        public string TimeAccepted { get; set; }
    }
}
