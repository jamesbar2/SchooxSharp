using System.Collections.Generic;
using System.Globalization;
using SchooxSharp.Api.Helpers;
using SchooxSharp.Api.Models;


namespace SchooxSharp.Api
{

    /// <summary>
    /// The following requests relate to getting information regarding the academy's 
    /// exams via the Schoox Academy API. Note: All requests must be Authenticated.
    /// </summary>
    public class Exams : SchooxApiBase
    {
        public Exams()
        {
            SService = new SchooxService();
        }

        public Exams(ISchooxService schooxService)
        {
            SService = schooxService;
        }

        /// <summary>
        /// Get a List of Exams
        /// </summary>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Max size of retrieved courses</param>
        /// <returns>Returns a list of all academy exams with extended details.</returns>
        public SchooxResponse<List<Exam>> GetExams(int? start = null, int? limit = null)
        {
            //GET /exams
            var request = SService.GenerateBaseRequest("/exams");
            
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<Exam>>(request);
        }

        /// <summary>
        /// Get a List of all Enrolled Users in an Exam
        /// </summary>
        /// <param name="examId">Exam ID</param>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Number of users to return per request, up to maximum of 1,000. Default to 100</param>
        /// <returns>Returns a list of all users that are enrolled in an exam with all of their performance statistics (e.g. date of last attempt, total score and points, passing or failure status).</returns>
        public SchooxResponse<List<User>> GetEnrolledUsersInExam(int examId, int? start = null, 
            int? limit = null)
        {
            //GET /exams/:examid/students
            var request = SService.GenerateBaseRequest("/exams/{examId}/students");

            request.AddUrlSegment("examId", examId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<User>>(request);
        }

        /// <summary>
        /// Get Exam Performance for a specific User
        /// </summary>
        /// <param name="examId">Exam ID</param>
        /// <param name="userId">User ID</param>
        /// <param name="start">Starting position</param>
        /// Returns detailed performance statistics of an exam for a specific user
        /// <returns></returns>
        public SchooxResponse<ExamPerformance> GetExamPerformanceForUser(int examId, int userId, int? start = null)
        {
            //GET /exams/:examid/students/:userid
            var request = SService.GenerateBaseRequest("/exams/{examId}/students/{userId}"); //, examId, userId);

            request.AddUrlSegment("examId", examId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("start", start);

            return Execute<ExamPerformance>(request);
        }


    }
}
