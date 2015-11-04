using System.Collections.Generic;
using System.Globalization;
using SchooxSharp.Api.Helpers;
using SchooxSharp.Api.Models;

namespace SchooxSharp.Api
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
