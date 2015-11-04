using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchooxSharp.Api.Models
{
    /// <summary>
    /// New User object since its much less complex than the standard user object
    /// </summary>
    public class NewUser
    {
        public NewUser()
        {
            
        }

        public NewUser(string firstName, string lastName, string password, string email, List<string> roles,
            List<int> aboveIds, List<int> unitIds, List<NewUserJob> jobs, string language)
        {
            Firstname = firstName;
            Lastname = lastName;
            Password = password;
            Email = email;
            Roles = roles;
            AboveIds = aboveIds;
            UnitIds = unitIds;
            Jobs = jobs;
            Language = language;
        }

        public NewUser(string firstName, string lastName, string password, string email, List<string> roles,
            List<int> aboveIds, List<int> unitIds, List<int> jobIds)
        {
            Firstname = firstName;
            Lastname = lastName;
            Password = password;
            Email = email;
            Roles = roles;
            AboveIds = aboveIds;
            UnitIds = unitIds;
            JobIds = jobIds;
        }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("above_ids")]
        public List<int> AboveIds { get; set; }

        [JsonProperty("unit_ids")]
        public List<int> UnitIds { get; set; }

        [JsonProperty("job_ids")]
        public List<int> JobIds { get; set; }
        
        [JsonProperty("jobs")]
        public List<NewUserJob> Jobs { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        public class NewUserJob
        {
            public NewUserJob(int? unitId, int? aboveId = null, params int[] jobs)
            {
                UnitId = unitId;
                Jobs = jobs.ToList();
                AboveId = aboveId;
            }

            [JsonProperty("unit_id")]
            public int? UnitId { get; set; }

            [JsonProperty("jobs")]
            public List<int> Jobs { get; set; }

            [JsonProperty("above_id")]
            public int? AboveId { get; set; }

            public override string ToString()
            {
                return string.Format("UnitId: {0}, Jobs: {1}, AboveId: {2}", UnitId, Jobs, AboveId);
            }
        }

        public override string ToString()
        {
            return
                string.Format(
                    "Firstname: {0}, Lastname: {1}, Password: {2}, Roles: {3}, Email: {4}, AboveIds: {5}, UnitIds: {6}, JobIds: {7}, Jobs: {8}, Language: {9}",
                    Firstname, Lastname, Password, Roles, Email, AboveIds, UnitIds, JobIds, Jobs, Language);
        }
    }

}
