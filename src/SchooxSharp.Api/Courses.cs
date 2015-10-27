using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            throw new NotImplementedException();
        }

        public SchooxResponse<List<Course>> GetListOfUserCourses(int userId, string tab = null, int? start = null,
            int? limit = null)
        {
            //GET /courses
            //https://www.schoox.com/api/v1/courses?userId=14&apikey=schoox&acadId=386


            throw new NotImplementedException();
        }

        public SchooxResponse<Course> GetDetailsForCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid
            //https://www.schoox.com/api/v1/courses/11657?apikey=schoox&acadId=386

            throw new NotImplementedException();
        }

        //List of Enrolled Users in a Course
        public SchooxResponse<List<User>> GetUsersEnrolledInCourse(int courseId, int? userId = null, int? start = null,
            int? limit = null)
        {
            //GET /courses/:courseid/students
            //https://www.schoox.com/api/v1/courses/11657/students?apikey=schoox&acadId=386

            throw new NotImplementedException();
        }
        
        //List of Lectures in a Course
        public SchooxResponse<List<Lecture>> GetLecturesInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/lectures
            //https://www.schoox.com/api/v1/courses/11657/lectures?apikey=schoox&acadId=386


            throw new NotImplementedException();
        }

        //List of Exams in a Course
        public SchooxResponse<List<Exam>> GetExamsInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/exams
            //https://www.schoox.com/api/v1/courses/11657/exams?apikey=schoox&acadId=386

            throw new NotImplementedException();
        }
        
        //List of Coupons in a Course
        public SchooxResponse<List<Coupon>> GetCouponsInCourse(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/coupons
            //https://www.schoox.com/api/v1/courses/46776/coupons?apikey=schoox&acadId=386

            throw new NotImplementedException();
        }
        
        //List of Enrolled Users in a Course Coupon
        public SchooxResponse<List<User>> GetUsersUsingCourseCoupon(int courseId, int couponId, int? userId = null)
        {
            //GET /courses/:courseid/coupons/:couponid
            //https://www.schoox.com/api/v1/courses/46776/coupons/5131?apikey=schoox&acadId=386

            throw new NotImplementedException();
        }

        
        //List of all Course Invitations
        public SchooxResponse<object> GetCourseInvitations(int courseId, int? userId = null)
        {
            //GET /courses/:courseid/invitations
            //https://www.schoox.com/api/v1/courses/11657/invitations?apikey=schoox&acadId=386

            //TODO: Figure out what this returns?

            throw new NotImplementedException();
        }
    }
}
