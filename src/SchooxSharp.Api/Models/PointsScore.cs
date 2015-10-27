using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class PointsScore
    {
        [JsonProperty("got")]
        public int Got { get; set; }

        [JsonProperty("all")]
        public int All { get; set; }

        public override string ToString()
        {
            return string.Format("Got: {0}, All: {1}", Got, All);
        }

     
    }
}
