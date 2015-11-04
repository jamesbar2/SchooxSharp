using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{

    public class AboveUnit
    {
        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, TypeId: {2}, TypeName: {3}", Id, Name, TypeId, TypeName);
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        [JsonProperty("type")]
        public string TypeName { get; set; }
    }

}
