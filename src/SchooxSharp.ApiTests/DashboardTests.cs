﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchooxSharp.Api;
namespace SchooxSharp.ApiTests
{
    [TestClass]
    public class DashboardTests
    {
        private Dashboard _dashboard;
        public static TestContext Context { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Context = context;
        }

        [TestInitializeAttribute]
        public void Initialize()
        {
            _dashboard = new Dashboard(new SchooxService("schoox", 386));
        }

        [TestMethod]
        public void GetUsersTest()
        {
            var response = _dashboard.GetUsers(Roles.Employee);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Users returned {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetUserCoursesTest()
        {
            var response = _dashboard.GetUserCourses(14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Courses returned {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetUserCurriculumsTest()
        {
            var response = _dashboard.GetUserCurriculums(14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Curriculums returned {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetUserExamsTest()
        {
            var response = _dashboard.GetUserExams(14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("User Exams returned {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetCoursesTest()
        {
            var response = _dashboard.GetCourses(Roles.Employee);

            Assert.IsNotNull(response);

            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Courses returned {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetEnrolledUsersInCourseTest()
        {
            var response = _dashboard.GetEnrolledUsersInCourse(11657, Roles.Employee, 1, 4, letter: "A", start: 0, limit: 100,
                sort: "firstname");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            //Assert.IsTrue(enrolledUsers.Data.Any());
            

            Context.WriteLine("Users returned {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetDetailedCourseProgressForUserTest()
        {
            var response = _dashboard.GetDetailedCourseProgressForUser(11657, 14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsNotNull(response.Data.Certificates);
            Assert.IsNotNull(response.Data.Exams);
            Assert.IsNotNull(response.Data.Lectures);

            Context.WriteLine("Certificates: {0}\nExams: {1}\nLectures: {2}", response.Data.Certificates.Count,
                response.Data.Exams.Count, response.Data.Lectures.Count);
        }

        [TestMethod]
        public void GetCurriculumsTest()
        {
            var response = _dashboard.GetCurriculums(Roles.Employee);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Curriculums: {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetEnrolledUsersInCurriculumTest()
        {
            var response = _dashboard.GetEnrolledUsersInCurriculum(37, Roles.Employee, 1, 4, 7, "A", 0, 100,
                "firstname");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Users in Curriculum: {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetCurriculumProgressForUserTest()
        {
            var response = _dashboard.GetCurriculumProgressForUser(37, 14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Curriculum Progress: {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetExamsTest()
        {
            var response = _dashboard.GetExams(Roles.Employee);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Exams: {0}", response.Data.Count);
        }

        [TestMethod]
        public void GetEnrolledUsersInExamTest()
        {
            var response = _dashboard.GetEnrolledUsersInExam(169, Roles.Employee, 1, 4, letter: "A", start:0, limit: 100, sort: "firstname");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Users: {0}", response.Data.Count);
        }
    }
}
