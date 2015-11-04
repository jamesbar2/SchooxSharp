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

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Code: {1}, Price: {2}, Discount: {3}, Quota: {4}, Active: {5}, TimeCreated: {6}, UserId: {7}, Type: {8}, MaxQuota: {9}, AcademyId: {10}, ExpirationDate: {11}, TimeAccepted: {12}",
                    Id, Code, Price, Discount, Quota, Active, TimeCreated, UserId, Type, MaxQuota, AcademyId,
                    ExpirationDate, TimeAccepted);
        }
    }
}
