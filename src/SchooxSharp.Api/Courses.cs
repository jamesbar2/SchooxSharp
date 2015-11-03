using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SchooxSharp.Api.Helpers;
using SchooxSharp.Api.Models;

namespace SchooxSharp.Api
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

        public SchooxResponse<List<Course>> GetListOfCourses(int? start = null, int? limit = null)
        {
            //GET /courses
            var request = SService.GenerateBaseRequest("/courses");
            request.AddNonBlankQueryString("start", start);
            request.AddNonBlankQueryString("limit", limit);

            //var content = Execute(request).Response;
            //var item = JsonConvert.DeserializeObject<List<Course>>(content);
            //BUG: Has an error parsing part of the request, but can deserialize just fine in the two lines above.

            //var courses = Execute(request);
            return Execute<List<Course>>(request);
        }

        public SchooxResponse<List<Course>> GetListOfUserCourses(int userId, string tab = null, int? start = null,
            int? limit = null)
        {
            //GET /courses
            //https://www.schoox.com/api/v1/courses?userId=14&apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses");

            request.AddUrlSegment("userId", userId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("tab", tab);
            request.AddNonBlankQueryString("start", start);

            //BUG: Has an error parsing part of the request, but can deserialize just fine in the two lines above.

            return Execute<List<Course>>(request);
        }

        public SchooxResponse<Course> GetDetailsForCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid
            //https://www.schoox.com/api/v1/courses/11657?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));
            request.AddNonBlankQueryString("userId", userId);

            //BUG: Has an error parsing part of the request, but can deserialize just fine in the two lines above.

            return Execute<Course>(request);
        }

        //List of Enrolled Users in a Course
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
        
        //List of Lectures in a Course
        public SchooxResponse<List<Lecture>> GetLecturesInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/lectures
            //https://www.schoox.com/api/v1/courses/11657/lectures?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/lectures");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<List<Lecture>>(request);
        }

        //List of Exams in a Course
        public SchooxResponse<List<Exam>> GetExamsInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/exams
            //https://www.schoox.com/api/v1/courses/11657/exams?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/exams");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<List<Exam>>(request);
        }
        
        //List of Coupons in a Course
        public SchooxResponse<List<Coupon>> GetCouponsInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/coupons
            //https://www.schoox.com/api/v1/courses/46776/coupons?apikey=schoox&acadId=386

            var request = SService.GenerateBaseRequest("/courses/{courseId}/coupons");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<List<Coupon>>(request);
        }
        
        //List of Enrolled Users in a Course Coupon
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

        
        //List of all Course Invitations
        public SchooxResponse<object> GetCourseInvitations(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/invitations
            //https://www.schoox.com/api/v1/courses/11657/invitations?apikey=schoox&acadId=386

            //TODO: Figure out what this returns?

            var request = SService.GenerateBaseRequest("/courses/{courseId}/invitations");
            request.AddUrlSegment("courseId", courseId.ToString(CultureInfo.InvariantCulture));

            request.AddNonBlankQueryString("userId", userId);

            return Execute<object>(request);
        }
    }
}
