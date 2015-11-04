using System.Collections.Generic;
using System.Globalization;
using SchooxSharp.Api.Helpers;
using SchooxSharp.Api.Models;
using SchooxSharp.Api.Services;

namespace SchooxSharp.Api.Clients
{
    public class Curriculums : SchooxApiBase
    {
        public Curriculums()
        {
            SService = new SchooxService();
        }

        public Curriculums(ISchooxService schooxService)
        {
            SService = schooxService;
        }

        /// <summary>
        /// Returns a list of all curriculums with extended details.
        /// </summary>
        /// <param name="userId">User's ID you want to retrieve his/her curriculum list view</param>
        /// <param name="start">Starting Position</param>
        /// <param name="limit">Max size of retrieved curriculums</param>
        /// <returns>A list of all curriculums with extended details</returns>
        public SchooxResponse<List<Curriculum>> GetCurriculums(int? userId = null, int? start = null, int? limit = null)
        {
            //GET /curriculums
            //https://www.schoox.com/api/v1/curriculums?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/curriculums");

            request.AddNonBlankQueryString("userId", userId);
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<Curriculum>>(request);
        }

        /// <summary>
        /// Returns a list of a user's enrolled & created curriculums with extended details by his/her schooX ID.
        /// </summary>
        /// <param name="userId">User's ID you want to retrieve his/her curriculum list view</param>
        /// <param name="start">Starting Position</param>
        /// <param name="limit">Max size of retrieved curriculums</param>
        /// <returns>A list of a user's enrolled & created curriculums with extended details</returns>
        public SchooxResponse<List<Curriculum>> GetUsersCurriculums(int userId, int? start = null, int? limit = null)
        {
            //GET /curriculums
            //https://www.schoox.com/api/v1/curriculums?userId=14&apikey=schoox&acadId=386


            var request = SService.GenerateBaseRequest("/curriculums");

            request.AddNonBlankQueryString("userId", userId);
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<Curriculum>>(request);
        }

        /// <summary>
        /// Returns extended details of a specific curriculum. A user's progress percentage, time spent 
        /// and enrollment date can be retrieved by his/her schooX ID.
        /// </summary>
        /// <param name="curriculumId">Curriculum ID</param>
        /// <param name="userId">User's ID you want to retrieve his/her curriculum list view</param>
        /// <returns>Extended details of a specific curriculum</returns>
        public SchooxResponse<Curriculum> GetDetailsForCurriculum(int curriculumId, int? userId = null)
        {
            //GET /curriculum/:curriculum
            //https://www.schoox.com/api/v1/curriculums/37?apikey=schoox&acadId=386
            //https://www.schoox.com/api/v1/curriculum/37?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/curriculums/{curriculumId}");
            request.AddUrlSegment("curriculumId", curriculumId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("userId", userId);

            return Execute<Curriculum>(request);
        }
    }
}
