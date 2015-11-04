using System.Collections.Generic;
using System.Globalization;
using SchooxSharp.Api.Helpers;
using SchooxSharp.Api.Models;
using SchooxSharp.Api.Services;

namespace SchooxSharp.Api.Clients
{
    public class Courses : SchooxApiBase
    {
        public Courses()
        {
            SService = new SchooxService();
        }

        public Courses(ISchooxService schooxService)
        {
            SService = schooxService;
        }

        /// <summary>
        /// Returns a list of all courses with extended details.
        /// </summary>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Max size of retrieved courses</param>
        /// <returns>List of all courses with extended details</returns>
        public SchooxResponse<List<Course>> GetListOfCourses(int? start = null, int? limit = null)
        {
            //GET /courses
            var request = SService.GenerateBaseRequest("/courses");
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<Course>>(request);
        }

        /// <summary>
        /// Returns a list of a user's enrolled & created courses with extended details by his/her schooX ID.
        /// </summary>
        /// <param name="userId">User ID of courses to retrieve.</param>
        /// <param name="tab"></param>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Max size of retrieved courses</param>
        /// <returns>List of courses the user is enrolled in</returns>
        public SchooxResponse<List<Course>> GetListOfUserCourses(int userId, string tab = null, int? start = null,
            int? limit = null)
        {
            //GET /courses
            //https://www.schoox.com/api/v1/courses?userId=14&apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses");

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("tab", tab);
            request.AddNonBlankQueryString("start", start);

            return Execute<List<Course>>(request);
        }

        /// <summary>
        /// Returns extended details of a specific course. A user's progress percentage, time spent and enrollment date can be retrieved by his/her schooX ID.
        /// </summary>
        /// <param name="courseId">Course ID for details.</param>
        /// <param name="userId">User's ID you want to retrieve his/her course list view</param>
        /// <returns>Extended details of a specific course</returns>
        public SchooxResponse<Course> GetDetailsForCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid
            //https://www.schoox.com/api/v1/courses/11657?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("userId", userId);

            return Execute<Course>(request);
        }

        /// <summary>
        /// Returns a list of a course's enrolled users with each user's enrolled date, progress percentage and time spent.
        /// </summary>
        /// <param name="courseId">Course ID </param>
        /// <param name="userId">User's ID you want to retrieve his/her course list view</param>
        /// <param name="start">Starting position</param>
        /// <param name="limit">Max size of retrieved courses</param>
        /// <returns>A list of a course's enrolled users with each user's enrolled date, progress percentage and time spent</returns>
        public SchooxResponse<List<User>> GetUsersEnrolledInCourse(int courseId, int? userId = null, int? start = null,
            int? limit = null)
        {
            //GET /courses/:courseid/students
            //https://www.schoox.com/api/v1/courses/11657/students?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/students");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            return Execute<List<User>>(request);
        }
        
        /// <summary>
        /// Returns a list of a course's lectures. You can retrieve a user's progress percentage, time spent and number of views for each lecture by his/her schooX ID.
        /// </summary>
        /// <param name="courseId">Course ID</param>
        /// <param name="userId">User's ID you want to retrieve his/her course list view</param>
        /// <returns>A list of a course's lectures. You can retrieve a user's progress percentage, time spent and number of views for each lecture</returns>
        public SchooxResponse<List<Lecture>> GetLecturesInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/lectures
            //https://www.schoox.com/api/v1/courses/11657/lectures?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/lectures");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<List<Lecture>>(request);
        }

        /// <summary>
        /// Returns a list of a course's exams. You can retrieve the date of his or her last attempt, total score and points as well as the passing or failure status for each exam by his/her schooX ID.
        /// </summary>
        /// <param name="courseId">Course ID</param>
        /// <param name="userId">User's ID you want to retrieve his/her course list view</param>
        /// <returns>A list of a course's exams</returns>
        public SchooxResponse<List<Exam>> GetExamsInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/exams
            //https://www.schoox.com/api/v1/courses/11657/exams?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/exams");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<List<Exam>>(request);
        }
        
        /// <summary>
        /// Returns a list of generated coupons for a specific course.
        /// </summary>
        /// <param name="courseId">Course ID</param>
        /// <param name="userId">User's ID you want to retrieve his/her course list view</param>
        /// <returns>A list of generated coupons for a specific course</returns>
        public SchooxResponse<List<Coupon>> GetCouponsInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/coupons
            //https://www.schoox.com/api/v1/courses/46776/coupons?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/coupons");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<List<Coupon>>(request);
        }
        
        /// <summary>
        /// Returns a list of a course's enrolled users for a specific coupon with each user's enrolled date, progress percentage and time spent.
        /// </summary>
        /// <param name="courseId">Course ID</param>
        /// <param name="couponId">Coupon ID</param>
        /// <param name="userId">User's ID you want to retrieve his/her course list view</param>
        /// <returns>A list of a course's enrolled users for a specific coupon with each user's enrolled date, progress percentage and time spent.</returns>
        public SchooxResponse<List<User>> GetUsersUsingCourseCoupon(int courseId, int couponId, int? userId = null)
        {
            //GET /courses/:courseid/coupons/:couponid
            //https://www.schoox.com/api/v1/courses/46776/coupons/5131?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/coupons/{couponId}");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("couponId", couponId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<List<User>>(request);
        }

        
        /// <summary>
        /// You can either assign a course to a user or invite the user to enroll in a course. If you assign the 
        /// course the user will automatically be enrolled in and the course in considered to be required. If you 
        /// send an invitation the user will have the option to enroll optionally. This request returns a list of 
        /// all invitations that have been sent for a particular course.
        /// </summary>
        /// <param name="courseId">Course ID</param>
        /// <param name="userId">User's ID you want to retrieve his/her course list view</param>
        /// <returns> a list of all invitations that have been sent for a particular course.</returns>
        public SchooxResponse<object> GetCourseInvitations(int courseId, int? userId = null)
        {
            //TODO: Figure out what object is returned.

            //GET /courses/:courseid/invitations
            //https://www.schoox.com/api/v1/courses/11657/invitations?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/invitations");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<object>(request);
        }
    }
}
