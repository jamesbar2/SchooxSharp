﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    public class Curriculum
    {    
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("total_time")]
        public string TotalTime { get; set; }

        [JsonProperty("enroll_date")]
        public string EnrollDate { get; set; }

        [JsonProperty("students")]
        public int Students { get; set; }

        [JsonProperty("completion_rate")]
        public int CompletionRate { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

    }
}