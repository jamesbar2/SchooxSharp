using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class Users
    {
        public ISchooxService SService { get; set; }

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
        public SchooxResponse<IEnumerable<object>> GetUsers(string role, string past = null, string search = null, 
            int? aboveId = null, int? unitId = null, int? jobId = null, int? start = null, int limit = 100)
        {
            //GET /users

            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns data for a specific user like first and last name, email, role, region, location, job code and his/her current status in the academy.
        /// </summary>
        /// <param name="externalId">Sets whether the id given is the external_id of the User.  By default, the value is "false"</param>
        /// <returns>Returns data for a specific user like first and last name, email, role, region, location, job code and his/her current status in the academy.</returns>
        public SchooxResponse<object> GetDetailsOfUser(string externalId = null)
        {
            //GET /users/:userid

            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates and adds a user to the academy. Password is mandatory.
        /// </summary>
        /// <param name="user">User object, password is required.  Use the static NewUserForAccount helper.</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse CreateAndAddUser(SchooxUser user)
        {
            //POST /users

            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates and adds multiple users (maximum of 10) to the academy via a single request. Password is mandatory.
        /// </summary>
        /// <param name="users">Enumerable lists of users to be added, password is required.  Use the static NewUserForAccount helper.</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse BulkCreateAndAddUsers(IEnumerable<SchooxUser> users)
        {
            //POST /users

            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a user through an academy invitation. You can simulate the inviting user by adding his/her schooX ID.
        /// </summary>
        /// <param name="user">User object to be invited, use the static NewUserForInvite helper.</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse InviteUser(SchooxUser user)
        {
            //POST /users

            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a user through an academy invitation. You can simulate the inviting user by adding his/her schooX ID.
        /// </summary>
        /// <param name="users">Enumerable list of user objects to be invited, use the static NewUserForInvite helper.</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse BulkInviteUsers(IEnumerable<SchooxUser> users)
        {
            //POST /users/bulk

            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit the firstname, lastname, email or password of a User.
        /// </summary>
        /// <param name="user">User to edit.</param>
        /// <param name="externalId">Sets whether the id given is the external_id of the User.  By default, the value is "false"</param>
        /// <returns>Response from Schoox</returns>
        public SchooxResponse EditUser(SchooxUser user, string externalId = null)
        {
            //PUT /users/:userid

            throw new NotImplementedException();
        }

        public SchooxResponse RemoveUser()
        {
            //DELETE /v1/users/:userid
            //TODO: Verify an additional "v1" is required

            throw new NotImplementedException();
        }

        public SchooxResponse ReactivateUser()
        {
            //POST /users

            throw new NotImplementedException();
        }

        public SchooxResponse AddNewJob()
        {
            //POST /jobs

            throw new NotImplementedException();
        }

        public SchooxResponse BulkAddNewJobs()
        {
            //POST /jobs/bulk

            throw new NotImplementedException();
        }

        public SchooxResponse EditJob()
        {
            //PUT /jobs/:jobid

            throw new NotImplementedException();
        }

        public SchooxResponse DeleteJob()
        {
            //DELETE /jobs/:jobid

            throw new NotImplementedException();
        }

        public SchooxResponse<IEnumerable<object>> GetJobs()
        {
            //GET /jobs

            throw new NotImplementedException();
        }

        public SchooxResponse UpdateUserRoles()
        {
            //PUT /users/:userid/roles

            throw new NotImplementedException();
        }

        public SchooxResponse UpdateUserJobs()
        {
            //PUT /users/:userid/jobs

            throw new NotImplementedException();
        }

        public SchooxResponse AddUnitsToUser()
        {
            //PUT /users/:userid/units

            throw new NotImplementedException();
        }

        public SchooxResponse RemoveUnitsFromUser()
        {
            //DELETE /users/:userid/units/:unitid

            throw new NotImplementedException();
        }

        public SchooxResponse AddAboveUnitsToUser()
        {
            //PUT /users/:userid/aboves

            throw new NotImplementedException();
        }

        public SchooxResponse RemoveAboveUnitFromUser()
        {
            //DELETE /users/:userid/aboves/:aboveid

            throw new NotImplementedException();
        }

        public SchooxResponse AddNewType()
        {
            //POST /types

            throw new NotImplementedException();
        }

        public SchooxResponse BulkAddNewTypes()
        {
            //POST /types/bulk

            throw new NotImplementedException();
        }

        public SchooxResponse EditType()
        {
            //PUT /types/:typeid

            throw new NotImplementedException();
        }

        public SchooxResponse DeleteType()
        {
            //DELETE /types/:typeid

            throw new NotImplementedException();
        }

        public SchooxResponse<IEnumerable<object>> GetTypes()
        {
            //GET /types

            throw new NotImplementedException();
        }

        public SchooxResponse AddNewAboveUnit()
        {
            //POST /aboves

            throw new NotImplementedException();
        }

        public SchooxResponse BulkAddNewAboveUnits()
        {
            //POST /aboves/bulk

            throw new NotImplementedException();
        }

        public SchooxResponse EditAboveUnit()
        {
            //PUT /aboves/:aboveid

            throw new NotImplementedException();
        }

        public SchooxResponse DeleteAboveUnit()
        {
            //PUT /aboves/:aboveid

            throw new NotImplementedException();
        }

        public SchooxResponse<IEnumerable<object>> GetAboveUnits()
        {
            //GET /aboves

            throw new NotImplementedException();
        }

        public SchooxResponse AddNewUnit()
        {
            //POST /units

            throw new NotImplementedException();
        }

        public SchooxResponse BulkAddNewUnits()
        {
            //POST /units/bulk

            throw new NotImplementedException();
        }

        public SchooxResponse EditUnit()
        {
            //PUT /units/:unitid

            throw new NotImplementedException();
        }

        public SchooxResponse DeleteUnit()
        {
            //DELETE /units/:unitid

            throw new NotImplementedException();
        }

        public SchooxResponse ListUnits()
        {
            //GET /units

            throw new NotImplementedException();
        }

        public SchooxResponse ArchiveUnit()
        {
            //PUT /units/:unitid

            throw new NotImplementedException();
        }

        public SchooxResponse UnarchiveUnit()
        {
            //PUT /units/archived/:unitid

            throw new NotImplementedException();
        }

        public SchooxResponse DeleteArchivedUnit()
        {
            //DELETE /units/archived/:unitid

            throw new NotImplementedException();
        }

        public SchooxResponse<IEnumerable<object>> GetArchivedUnits()
        {
            //GET /units/archived

            throw new NotImplementedException();
        }
    }

    public class SchooxUser
    {
    }
}