using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using SchooxSharp.Api.Helpers;
using SchooxSharp.Api.Models;
using SchooxSharp.Api.Services;

namespace SchooxSharp.Api.Clients
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
        /// <returns>SchooxResponse with status information</returns>
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
        /// <returns>SchooxResponse with status information</returns>
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
        /// <returns>SchooxResponse with status information</returns>
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
        /// <returns>SchooxResponse with status information</returns>
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
        /// <returns>SchooxResponse with status information</returns>
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
        /// Removes a user from the academy.
        /// </summary>
        /// <param name="userId">User to remove</param>
        /// <param name="externalId">External ID of user to reactivate</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Reactivates a Past Employee as Employee. You can use the User Id or his/her external_id
        /// </summary>
        /// <param name="userId">User ID of user to reactivate</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Reactivates a Past Employee as Employee. You can use the User Id or his/her external_id
        /// </summary>
        /// <param name="externalId">External ID of user to reactivate</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Creates a new job
        /// </summary>
        /// <param name="job">Job name, and report_id</param>
        /// <returns>SchooxResponse with status information</returns>
        public SchooxResponse AddNewJob(NewJob job)
        {
            //POST /jobs
            //https://www.schoox.com/api/v1/jobs?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/jobs");
            request.Method = Method.POST;
            request.AddJsonBody(job);

            return Execute(request);
        }

        /// <summary>
        /// Creates multiple academy jobs via a single request
        /// </summary>
        /// <param name="jobs">Jobs to be created</param>
        /// <returns>SchooxResponse with status information</returns>
        public SchooxResponse BulkAddNewJobs(List<NewJob> jobs )
        {
            //POST /jobs/bulk
            //https://www.schoox.com/api/v1/jobs/bulk?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/jobs/bulk");
            request.Method = Method.POST;
            request.AddJsonBody(jobs);

            return Execute(request);
        }

        /// <summary>
        /// Changes the name and/or the report id of a job.
        /// </summary>
        /// <param name="jobId">Job ID to be edited</param>
        /// <param name="job">Updated job information</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Deletes a specified job. It also removes the job from all assigned users.
        /// </summary>
        /// <param name="jobId">Job ID to be deleted</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Returns a list with all jobs of your Academy.
        /// </summary>
        /// <param name="search">Search by Job title</param>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Max items returned per request. Default is 100</param>
        /// <returns>List of Jobs</returns>
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

        /// <summary>
        /// Edit the roles of a given user.
        /// Available roles are (see Constants.Roles):
        /// admin, training_manager, content_manager, professional_instructor, hourly_worker
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <param name="externalId">External ID of user to reactivate</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Edit the jobs of a given user by an array of units/above units & their job Ids. User must be previously assigned to the specified units & above units.
        /// </summary>
        /// <param name="userId">User to update</param>
        /// <param name="jobs">Jobs of the user (Models.UpdateUserJob)</param>
        /// <param name="externalId">External ID of user to reactivate</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Adds Units to a given User by an array of Unit Ids.
        /// </summary>
        /// <param name="userId">User to add units to</param>
        /// <param name="unitIds">Unit IDs to add</param>
        /// <param name="externalId">External ID of user to reactivate</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Adds Units to a given User by an array of Unit Ids.
        /// </summary>
        /// <param name="userId">User to remove units from</param>
        /// <param name="unitId">Unit to remove</param>
        /// <param name="externalId">External ID of user to reactivate</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Adds Aboves Units to a given User by an array of Above Unit Ids.
        /// </summary>
        /// <param name="userId">User to add above units to</param>
        /// <param name="aboveUnitIds">Above units to add</param>
        /// <param name="externalId">External ID of user to reactivate</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Removes an Above Unit from a given User
        /// </summary>
        /// <param name="userId">User to remove above units from</param>
        /// <param name="aboveId">Above unit to remove</param>
        /// <param name="externalId">External ID of user to reactivate</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Creates a new Type.
        /// </summary>
        /// <param name="typeName">Type name to add</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Creates multiple Types via a single request.
        /// </summary>
        /// <param name="typeNames">Type names as a list</param>
        /// <returns>SchooxResponse with status information</returns>
        public SchooxResponse BulkAddNewTypes(List<string> typeNames )
        {
            //POST /types/bulk
            //https://www.schoox.com/api/v1/types/bulk?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/types");
            request.Method = Method.POST;

            request.AddJsonBody(typeNames.Select(u => new {name = u}));

            return Execute(request);
        }
         
        /// <summary>
        /// Changes the name of a Type.
        /// </summary>
        /// <param name="typeId">Type ID to edit</param>
        /// <param name="typeName">New type name</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Deletes a specified type.
        /// </summary>
        /// <param name="typeId">Type to delete</param>
        /// <returns>SchooxResponse with status information</returns>
        public SchooxResponse DeleteType(int typeId)
        {
            //DELETE /types/:typeid
            //https://www.schoox.com/api/v1/types/0?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/types/{typeId}");
            request.Method = Method.DELETE;

            request.AddUrlSegment("typeId", typeId.ToString(CultureInfo.InvariantCulture));

            return Execute(request);
        }

        /// <summary>
        /// Returns a list of all Types of your Academy.
        /// </summary>
        /// <returns>List of Academy Types</returns>
        public SchooxResponse<List<AcademyType>> GetTypes()
        {
            //GET /types
            //https://www.schoox.com/api/v1/types?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/types");

            return Execute<List<AcademyType>>(request);
        }

        /// <summary>
        /// Creates a new Above Unit and connects it to a Type.
        /// </summary>
        /// <param name="aboveUnit">Above unit to add</param>
        /// <returns>SchooxResponse with status information</returns>
        public SchooxResponse AddNewAboveUnit(AboveUnit aboveUnit)
        {
            //POST /aboves
            //https://www.schoox.com/api/v1/aboves?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/aboves");
            request.Method = Method.POST;

            request.AddJsonBody(aboveUnit);

            return Execute(request);
        }

        /// <summary>
        /// Creates multiple Above Units (maximum of 100) via a single request.
        /// </summary>
        /// <param name="aboveUnits"></param>
        /// <returns>SchooxResponse with status information</returns>
        public SchooxResponse BulkAddNewAboveUnits(List<AboveUnit> aboveUnits )
        {
            if (aboveUnits != null && aboveUnits.Count > 100)
                throw new ArgumentOutOfRangeException("aboveUnits", "Too many aboveUnits, maximum is 100.");

            //POST /aboves/bulk
            //https://www.schoox.com/api/v1/aboves/bulk?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/aboves/bulk");
            request.Method = Method.POST;

            request.AddJsonBody(aboveUnits);

            return Execute(request);
        }

        /// <summary>
        /// Changes the name and/or the type of an Above Unit.
        /// </summary>
        /// <param name="aboveId">Above Unit ID to be edited</param>
        /// <param name="aboveUnit">Updated AboveUnit object</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Changes the name and/or the type of an Above Unit.
        /// </summary>
        /// <param name="aboveId">Above Unit to be deleted</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Returns a list of Above Units (max. 100/request) of your Academy.
        /// </summary>
        /// <param name="typeId">Filter Above Units by Type ID</param>
        /// <param name="search">Search by Above Unit title</param>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Number of Above Units to return per request, up to maximum of 100,000. Default to 100</param>
        /// <returns>List of Above Units</returns>
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

        /// <summary>
        /// Creates a new Unit and connects it to Above Units, via an array of Above Unit ids (above_ids) or an array of Above Unit names (above_names).
        /// </summary>
        /// <param name="unit">Unit with names and above IDs</param>
        /// <returns>SchooxResponse with status information</returns>
        public SchooxResponse AddNewUnit(NewUnit unit)
        {
            //POST /units
            //https://www.schoox.com/api/v1/units?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/units");
            request.Method = Method.POST;

            request.AddJsonBody(unit);

            return Execute(request);
        }

        /// <summary>
        /// Creates multiple Units (maximum of 100) via a single request.
        /// </summary>
        /// <param name="units">Units to add</param>
        /// <returns>SchooxResponse with status information</returns>
        public SchooxResponse BulkAddNewUnits(List<NewUnit> units )
        {
            if(units != null && units.Count > 100)
                throw new ArgumentOutOfRangeException("units", "Maximum to add is 100.");

            //POST /units/bulk
            //https://www.schoox.com/api/v1/units/bulk?apikey=schoox&acadId=386
            var request = SService.GenerateBaseRequest("/units");
            request.Method = Method.POST;

            request.AddJsonBody(units);

            return Execute(request);
        }

        /// <summary>
        /// Changes the name and/or the above units of a Unit.
        /// </summary>
        /// <param name="unitId">Unit to change</param>
        /// <param name="unit">Updated unit</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Deletes a specific Unit.
        /// </summary>
        /// <param name="unitId">Unit to delete</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Returns a list of Units of your Academy.
        /// </summary>
        /// <param name="search">Search by Unit title</param>
        /// <param name="searchAbove">Filter by Above Unit title</param>
        /// <param name="aboveId">Filter Units by an Above Unit Id</param>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Number of Units to return per request, up to maximum of 100,000. Default to 100</param>
        /// <returns>List of Units (may be null)</returns>
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

        /// <summary>
        /// Archive a Unit.
        /// </summary>
        /// <param name="unitId">Unit to archive</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Unarchive a Unit.
        /// </summary>
        /// <param name="unitId">Unit to unarchive.</param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Deletes a specific Archived Unit.
        /// </summary>
        /// <param name="unitId">Archived unit to delete </param>
        /// <param name="title">Sets whether the id given is the current title. By default, the value is "false"</param>
        /// <returns>SchooxResponse with status information</returns>
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

        /// <summary>
        /// Returns a list of Archived Units of your Academy.
        /// </summary>
        /// <param name="search">Search by Unit title</param>
        /// <param name="searchAbove">Filter by Above Unit title</param>
        /// <param name="aboveId">Filter Units by an Above Unit Id</param>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Number of Units to return per page, up to maximum of 10,000. Default to 100</param>
        /// <returns>List of Archived Units (may be null)</returns>
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