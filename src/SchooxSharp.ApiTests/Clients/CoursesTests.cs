using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchooxSharp.Api.Clients;
using SchooxSharp.Api.Services;

namespace SchooxSharp.Api.Tests.Clients
{
    [TestClass()]
    public class CoursesTestsBase :SchooxTestBase
    {
        private Courses _courses;
        public static TestContext Context { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Context = context;
        }

        [TestInitialize]
        public void Initialize()
        {
            _courses = new Courses(new SchooxService("schoox", 386));
        }

        [TestMethod()]
        public void GetListOfCoursesTest()
        {
            var response = _courses.GetListOfCourses();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Courses returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetListOfUserCoursesTest()
        {
            var response = _courses.GetListOfUserCourses(3, "you", 0, 100);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Courses returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetDetailsForCourseTest()
        {
            var response = _courses.GetDetailsForCourse(11657);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);

            Context.WriteLine("Courses returned {0}", response.Data);
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetUsersEnrolledInCourseTest()
        {
            var response = _courses.GetUsersEnrolledInCourse(11657);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Users returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));

        }

        [TestMethod()]
        public void GetLecturesInCourseTest()
        {
            var response = _courses.GetLecturesInCourse(11657);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Lectures returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetExamsInCourseTest()
        {
            var response = _courses.GetExamsInCourse(11657);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Exams returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetCouponsInCourseTest()
        {
            var response = _courses.GetCouponsInCourse(46776);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Coupons returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetUsersUsingCourseCouponTest()
        {
            var response = _courses.GetUsersUsingCourseCoupon(46776, 5131);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Users returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetCourseInvitationsTest()
        {
            var response = _courses.GetCourseInvitations(46776);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
           
            //TODO: Figure out the model for this, there is none in the documentation.

            //Context.WriteLine("Coupons returned {0}", response.Data.Count);
            //foreach (var i in response.Data)
            //    Context.WriteLine(i.ToString());
            //Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }
    }
}
