using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{

    public class UpdateUserJob
    {
        public UpdateUserJob()
        {
            
        }

        public UpdateUserJob(int? unit, int? aboveUnit, params int[] jobs)
        {
            Unit = unit;
            AboveUnit = aboveUnit;
            Jobs = jobs.ToList();
        }

        [JsonProperty("unit")]
        public int? Unit { get; set; }

        [JsonProperty("jobs")]
        public List<int> Jobs { get; set; }

        [JsonProperty("above_unit")]
        public int? AboveUnit { get; set; }
    }

}
