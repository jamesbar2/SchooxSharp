using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SchooxSharp.Api.Helpers;


namespace SchooxSharp.Api
{

    /// <summary>
    /// The following requests relate to getting information regarding the academy's 
    /// exams via the Schoox Academy API. Note: All requests must be Authenticated.
    /// </summary>
    public class Exams
    {
        public ISchooxService SService { get; set; }

        public Exams()
        {
            SService = new SchooxService();
        }

        public Exams(ISchooxService schooxService)
        {
            SService = schooxService;
        }

        public SchooxResponse<List<object>> GetExams(int? start = null, int? limit = null)
        {
            //TODO: Validate 

            //GET /exams
            var path = "/exams";
            
            //var db = new DictionaryQueryBuilder();
            //db.Add("start", start);
            //db.Add("limit",limit);

            throw new NotImplementedException();
        }

        public SchooxResponse<List<object>> GetEnrolledUsersInExam(int examId, int? start = null, 
            int? limit = null)
        {
            //TODO: Validate 

            //GET /exams/15/students?acadid=123&start=&limit=100
            var path = string.Format("/exams/{0}/students", examId);

            //var db = new DictionaryQueryBuilder();
            //db.Add("start", start);
            //db.Add("limit", limit);

            throw new NotImplementedException();
        }

        public SchooxResponse<object> GetExamPerformanceForUser(int examId, int userId, int? start = null)
        {
            //TODO: Validate 

            //GET /exams/:examid/students/:userid
            var path = string.Format("/exams/{0}/students/{1}", examId, userId);

            //var db = new DictionaryQueryBuilder();
            //db.Add("start", start);

            throw new NotImplementedException();

        }


    }
}
