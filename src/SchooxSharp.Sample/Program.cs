using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchooxSharp.Api;
using SchooxSharp.Api.Constants;

namespace SchooxSharp.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //note the App.config file that has the values for auto loading the configuration
            var schooxService = new SchooxService();

            var dashboard = new Dashboard(schooxService);
            var courses = new Courses(schooxService);

            //lets get the courses
            var coursesResponse = dashboard.GetCourses(Roles.SchooxInternalEmployee);

            if (coursesResponse.RequestSuccessful && coursesResponse.Data != null)
            {
                Console.WriteLine("Request from\n{0}\n{1} courses returned:", coursesResponse.Response.ResponseUri,
                    coursesResponse.Data.Count);
                foreach (var course in coursesResponse.Data)
                {
                    Console.WriteLine("#{0} - {1} - # of Students: {2}", course.Id, course.Title, course.Students);
                }

                //now that we have the courses, let's pull details for the first one
                var firstCourse = coursesResponse.Data.FirstOrDefault();

                if (firstCourse != null)
                {
                    var courseDetail = courses.GetDetailsForCourse(firstCourse.Id);
                    Console.WriteLine("\nDetails for Course:\n{0}", courseDetail.Data);
                }
            }
            else
            {
                Console.WriteLine("No courses found for {0}, check the URL\n{1}.", Roles.SchooxInternalEmployee,
                    coursesResponse.Response.ResponseUri);
            }

            Console.Read();
        }
    }
}
