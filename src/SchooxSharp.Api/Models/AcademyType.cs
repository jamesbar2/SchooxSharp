using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SchooxSharp.Api.Models
{
    public class AcademyType
    {
        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", Id, Name);
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
