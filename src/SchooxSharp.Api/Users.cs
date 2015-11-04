using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using SchooxSharp.Api.Helpers;
using SchooxSharp.Api.Models;

namespace SchooxSharp.Api
{
    /// <summary>
    /// The following requests relate to getting information about users via the Schoox 
    /// Academy API. Note: All requests must be Authenticated. Access Level for all requests: 
    /// Administrators, Training Managers, Region and Location Managers. Depending on the 
    /// role the requests return data either for all users (Access level: Administrators 
    /// and Training Managers) or for users that belong to a certain region or location 
    /// (Access Level: Region Managers, Local Managers). You can simulate a user's view by 
    /// his/her schooX ID.
    /// </summary>
    public class Users : SchooxApiBase
    {
        public Users()
        {
            SService = new SchooxService();
        }

        public Users(ISchooxService service)
        {
            SService = service;
        }

        /// <summary>
        /// Returns a list of academy's users. A role must be specified. Available values are: employee, customer, instructor & member.
        /// </summary>
        /// <param name="role">Role of users</param>
        /// <param name="past">List Past Employees if given role is "employee". Default value is "false"</param>
        /// <param name="search">Search by user's firstname or lastname</param>
        /// <param name="aboveId">Above Unit's ID</param>
        /// <param name="unitId">Unit's ID</param>
        /// <param name="jobId">Job's ID</param>
        /// <param name="start">Starting Position</param>
        /// <param name="limit">Number of users to return per request, up to maximum of 1,000. Default to 100</param>
        /// <returns>Returns a list of academy's users.</returns>
        public SchooxResponse<List<User>> GetUsers(string role, string past = null, string search = null, 
            int? aboveId = null, int? unitId = null, int? jobId = null, int? start = null, int? limit = null)
        {
            //GET /users
            //https://www.schoox.com/api/v1/users?role=employee&apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users");
            request.AddNonBlankQueryString("role", role);
            request.AddNonBlankQueryString("past", past);
            request.AddNonBlankQueryString("search", search);
            request.AddNonBlankQueryString("aboveId", aboveId);
            request.AddNonBlankQueryString("unitId", unitId);
            request.AddNonBlankQueryString("jobId", jobId);
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<User>>(request);
        }

        /// <summary>
        /// Returns data for a specific user like first and last name, email, role, region, location, job code and his/her current status in the academy.
        /// </summary>
        /// <param name="userId">User's ID.</param>
        /// <param name="externalId">Sets whether the id given is the external_id of the User.  By default, the value is "false"</param>
        /// <returns>Returns data for a specific user like first and last name, email, role, region, location, job code and his/her current status in the academy.</returns>
        public SchooxResponse<User> GetDetailsOfUser(int userId, string externalId = null)
        {
            //GET /users/:userid
            //https://www.schoox.com/api/v1/users/14?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users/{userId}");
            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("externalId", externalId);

            return Execute<User>(request);
        }

        /// <summary>
        /// Creates and adds a user to the academy. Password is mandatory.
        /// </summary>
        /// <param name="user">User object, password is required.  Use the static NewUserForAccount helper.</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse CreateAndAddUser(NewUser user)
        {
            //POST /users
            //https://www.schoox.com/api/v1/users?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users");
            request.Method = Method.POST;
            request.AddJsonBody(user);

            return Execute(request);
        }

        /// <summary>
        /// Creates and adds multiple users (maximum of 10) to the academy via a single request. Password is mandatory.
        /// </summary>
        /// <param name="users">Enumerable lists of users to be added, password is required.  Use the static NewUserForAccount helper.</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse BulkCreateAndAddUsers(List<NewUser> users)
        {
            //POST /users
            //https://www.schoox.com/api/v1/users?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users");
            request.Method = Method.POST;
            request.AddJsonBody(users);

            return Execute(request);
        }

        /// <summary>
        /// Adds a user through an academy invitation. You can simulate the inviting user by adding his/her schooX ID.
        /// </summary>
        /// <param name="user">User object to be invited, use the static NewUserForInvite helper.</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse InviteUser(NewUser user)
        {
            //POST /users
            //https://www.schoox.com/api/v1/users?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users");
            request.Method = Method.POST;
            request.AddJsonBody(user);

            return Execute(request);
        }

        /// <summary>
        /// Adds a user through an academy invitation. You can simulate the inviting user by adding his/her schooX ID.
        /// </summary>
        /// <param name="users">Enumerable list of user objects to be invited, use the static NewUserForInvite helper.</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse BulkInviteUsers(List<NewUser> users)
        {
            //POST /users/bulk
            //https://www.schoox.com/api/v1/users/bulk?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users/bulk");
            request.Method = Method.POST;

            request.AddJsonBody(users);

            return Execute(request);
        }

        /// <summary>
        /// Edit the firstname, lastname, email or password of a User.
        /// </summary>
        /// <param name="userId">Users ID</param>
        /// <param name="user">User to edit.</param>
        /// <param name="externalId">Sets whether the id given is the external_id of the User.  By default, the value is "false"</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse EditUser(int userId, NewUser user, string externalId = null)
        {
            //PUT /users/:userid
            //https://www.schoox.com/api/v1/users/1234567890?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users/{userId}");
            request.Method = Method.PUT;

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("external_id", externalId);
            request.AddJsonBody(user);

            return Execute(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="externalId"></param>
        /// <returns></returns>
        public SchooxResponse RemoveUser(int userId, string externalId = null)
        {
            //DELETE /v1/users/:userid
            //https://www.schoox.com/api/v1/users/14?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/users/{userId}");
            request.Method = Method.DELETE;

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("external_id", externalId);

            return Execute(request);
        }

        public SchooxResponse ReactivateUser(int userId)
        {
            //POST /users
            //https://www.schoox.com/api/v1/users?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/users");
            request.Method = Method.POST;

            request.AddJsonBody(
                new
                {
                    id = userId
                });

            return Execute(request);
        }

        public SchooxResponse ReactivateUser(string externalId)
        {
            //POST /users
            //https://www.schoox.com/api/v1/users?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/users");
            request.Method = Method.POST;

            request.AddJsonBody(
                new
                {
                    external_id = externalId
                });

            return Execute(request);
        }

        public SchooxResponse AddNewJob(NewJob job)
        {
            //POST /jobs
            //https://www.schoox.com/api/v1/jobs?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/jobs");
            request.Method = Method.POST;
            request.AddJsonBody(job);

            return Execute(request);
        }

        public SchooxResponse BulkAddNewJobs(List<NewJob> jobs )
        {
            //POST /jobs/bulk
            //https://www.schoox.com/api/v1/jobs/bulk?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/jobs/bulk");
            request.Method = Method.POST;
            request.AddJsonBody(jobs);

            return Execute(request);
        }

        public SchooxResponse EditJob(int jobId, NewJob job, string title = null)
        {
            //PUT /jobs/:jobid
            //https://www.schoox.com/api/v1/jobs/$d?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/jobs/{jobId}");
            request.Method = Method.PUT;

            request.AddUrlSegment("jobId", jobId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);
            request.AddJsonBody(job);

            return Execute(request);
        }

        public SchooxResponse DeleteJob(int jobId, string title = null)
        {
            //DELETE /jobs/:jobid
            //https://www.schoox.com/api/v1/jobs/230?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/jobs/{jobId}");
            request.Method = Method.DELETE;

            request.AddUrlSegment("jobId", jobId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);

            return Execute(request);
        }

        public SchooxResponse<List<Job>> GetJobs(string search = null, int? start = null, int? limit = null)
        {
            //GET /jobs
            //https://www.schoox.com/api/v1/jobs?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/jobs");
            request.AddNonBlankQueryString("search", search);
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<Job>>(request);
        }

        public SchooxResponse UpdateUserRoles(int userId, List<string> roles, string externalId = null)
        {
            //PUT /users/:userid/roles
            //https://www.schoox.com/api/v1/users/14/roles?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users/{userId}/roles");
            request.Method = Method.PUT;

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("external_id", externalId);
            request.AddJsonBody(roles);

            return Execute(request);
        }

        public SchooxResponse UpdateUserJobs(int userId, List<UpdateUserJob> jobs, string externalId = null)
        {
            //PUT /users/:userid/jobs
            //https://www.schoox.com/api/v1/users/14/jobs?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/users/{userId}/jobs");
            request.Method = Method.PUT;

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("external_id", externalId);
            request.AddJsonBody(jobs);

            return Execute(request);
        }

        public SchooxResponse AddUnitsToUser(int userId, List<int> unitIds, string externalId = null, string title = null )
        {
            //PUT /users/:userid/units
            //https://www.schoox.com/api/v1/users/14/units?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/users/{userId}/units");
            request.Method = Method.PUT;

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("external_id", externalId);
            request.AddNonBlankQueryString("title", title);
            request.AddJsonBody(unitIds);

            return Execute(request);
        }

        public SchooxResponse RemoveUnitsFromUser(int userId, int unitId, string externalId = null, string title = null)
        {
            //DELETE /users/:userid/units/:unitid
            //https://www.schoox.com/api/v1/users/14/units/35?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/users/{userId}/units/{unitId}");
            request.Method = Method.DELETE;
           
            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("unitId", unitId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("external_id", externalId);
            request.AddNonBlankQueryString("title", title);

            return Execute(request);
        }

        public SchooxResponse AddAboveUnitsToUser(int userId, List<int> aboveUnitIds, string externalId = null, string title = null)
        {
            //PUT /users/:userid/aboves
            //https://www.schoox.com/api/v1/users/14/aboves?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/users/{userId}/aboves");
            request.Method = Method.PUT;

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("external_id", externalId);
            request.AddNonBlankQueryString("title", title);

            request.AddJsonBody(aboveUnitIds);

            return Execute(request);
        }

        public SchooxResponse RemoveAboveUnitFromUser(int userId, int aboveId, string externalId = null, string title = null)
        {
            //DELETE /users/:userid/aboves/:aboveid
            //https://www.schoox.com/api/v1/users/14/aboves/35?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/users/{userId}/aboves/{aboveId}");
            request.Method = Method.DELETE;

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("aboveId", aboveId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("external_id", externalId);
            request.AddNonBlankQueryString("title", title);

            return Execute(request);
        }

        public SchooxResponse AddNewType(string typeName)
        {
            //POST /types
            //https://www.schoox.com/api/v1/types?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/types");
            request.Method = Method.POST;

            request.AddJsonBody(new
            {
                name = typeName
            });

            return Execute(request);
        }

        public SchooxResponse BulkAddNewTypes(List<string> typeNames )
        {
            //POST /types/bulk
            //https://www.schoox.com/api/v1/types/bulk?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/types");
            request.Method = Method.POST;

            request.AddJsonBody(typeNames.Select(u => new {name = u}));

            return Execute(request);
        }

        public SchooxResponse EditType(int typeId, string typeName)
        {
            //PUT /types/:typeid
            //https://www.schoox.com/api/v1/types/0?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/types/{typeId}");
            request.Method = Method.PUT;

            request.AddUrlSegment("typeId", typeId.ToString(CultureInfo.InvariantCulture));
            
            request.AddJsonBody(new
            {
                name = typeName
            });

            return Execute(request);
        }

        public SchooxResponse DeleteType(int typeId)
        {
            //DELETE /types/:typeid
            //https://www.schoox.com/api/v1/types/0?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/types/{typeId}");
            request.Method = Method.DELETE;

            request.AddUrlSegment("typeId", typeId.ToString(CultureInfo.InvariantCulture));

            return Execute(request);
        }

        public SchooxResponse<List<AcademyType>> GetTypes()
        {
            //GET /types
            //https://www.schoox.com/api/v1/types?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/types");

            return Execute<List<AcademyType>>(request);
        }

        public SchooxResponse AddNewAboveUnit(AboveUnit aboveUnit)
        {
            //POST /aboves
            //https://www.schoox.com/api/v1/aboves?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/aboves");
            request.Method = Method.POST;

            request.AddJsonBody(aboveUnit);

            return Execute(request);
        }

        public SchooxResponse BulkAddNewAboveUnits(List<AboveUnit> aboveUnits )
        {
            //POST /aboves/bulk
            //https://www.schoox.com/api/v1/aboves/bulk?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/aboves/bulk");
            request.Method = Method.POST;

            request.AddJsonBody(aboveUnits);

            return Execute(request);
        }

        public SchooxResponse EditAboveUnit(int aboveId, AboveUnit aboveUnit, string title = null)
        {
            //PUT /aboves/:aboveid
            //https://www.schoox.com/api/v1/aboves/20?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/aboves/{aboveId}");
            request.Method = Method.PUT;

            request.AddUrlSegment("aboveId", aboveId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);

            request.AddJsonBody(aboveUnit);

            return Execute(request);
        }

        public SchooxResponse DeleteAboveUnit(int aboveId, string title = null)
        {
            //DELETE /aboves/:aboveid
            //https://www.schoox.com/api/v1/aboves/20?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/aboves/{aboveId}");
            request.Method = Method.DELETE;

            request.AddUrlSegment("aboveId", aboveId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);

            return Execute(request);
        }

        public SchooxResponse<List<AboveUnit>> GetAboveUnits(int? typeId = null, string search = null, int? start = null, int? limit = null)
        {
            //GET /aboves
            //https://www.schoox.com/api/v1/aboves?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/aboves");

            request.AddNonBlankQueryString("type_id", typeId);
            request.AddNonBlankQueryString("search", search);
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<AboveUnit>>(request);
        }

        public SchooxResponse AddNewUnit(NewUnit unit)
        {
            //POST /units
            //https://www.schoox.com/api/v1/units?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/units");
            request.Method = Method.POST;

            request.AddJsonBody(unit);

            return Execute(request);
        }

        public SchooxResponse BulkAddNewUnits(List<NewUnit> units )
        {
            //POST /units/bulk
            //https://www.schoox.com/api/v1/units/bulk?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/units");
            request.Method = Method.POST;

            request.AddJsonBody(units);

            return Execute(request);
        }

        public SchooxResponse EditUnit(int unitId, NewUnit unit, string title = null)
        {
            //PUT /units/:unitid
            //https://www.schoox.com/api/v1/units/35?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/units/{unitId}");
            request.Method = Method.PUT;

            request.AddUrlSegment("unitId", unitId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);

            request.AddJsonBody(unit);

            return Execute(request);
        }

        public SchooxResponse DeleteUnit(int unitId, string title = null)
        {
            //DELETE /units/:unitid
            //https://www.schoox.com/api/v1/units/35?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/units/{unitId}");
            request.Method = Method.DELETE;

            request.AddUrlSegment("unitId", unitId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);

            return Execute(request);
        }

        public SchooxResponse<List<Unit>> GetUnits(string search = null, string searchAbove = null, int? aboveId = null, int? start = null, int? limit = null)
        {
            //GET /units
            //https://www.schoox.com/api/v1/units?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/units");

            request.AddNonBlankQueryString("search", search);
            request.AddNonBlankQueryString("search_above", searchAbove);
            request.AddNonBlankQueryString("above_id", aboveId);
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            var content = Execute(request).Response.Content;
            var units = JsonConvert.DeserializeObject<List<Unit>>(content);

            return Execute<List<Unit>>(request);
        }

        public SchooxResponse ArchiveUnit(int unitId, string title = null)
        {
            //PUT /units/:unitid
            //https://www.schoox.com/api/v1/units/35?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/units/{unitId}");
            request.Method = Method.PUT;

            request.AddUrlSegment("unitId", unitId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);

            request.AddJsonBody(new
            {
                archive = true
            });

            return Execute(request);
        }

        public SchooxResponse UnarchiveUnit(int unitId, string title = null)
        {
            //PUT /units/archived/:unitid
            //https://www.schoox.com/api/v1/units/archived/35?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/units/archived/{unitId}");
            request.Method = Method.PUT;

            request.AddUrlSegment("unitId", unitId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);

            request.AddJsonBody(new
            {
                archive = false
            });

            return Execute(request);
        }

        public SchooxResponse DeleteArchivedUnit(int unitId, string title = null)
        {
            //DELETE /units/archived/:unitid
            //https://www.schoox.com/api/v1/units/archived/35?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/units/archived/{unitId}");
            request.Method = Method.DELETE;

            request.AddUrlSegment("unitId", unitId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("title", title);

            return Execute(request);
        }


        public SchooxResponse<List<Unit>> GetArchivedUnits(string search = null, string searchAbove = null, int? aboveId = null, int? start = null, int? limit = null)
        {
            //GET /units/archived
            //https://www.schoox.com/api/v1/units/archived?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/units/archived");

            request.AddNonBlankQueryString("search", search);
            request.AddNonBlankQueryString("search_above", searchAbove);
            request.AddNonBlankQueryString("above_id", aboveId);
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<Unit>>(request);
        }
    }

}