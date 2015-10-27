using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchooxSharp.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchooxSharp.ApiTests
{
    [TestClass()]
    public class ExamsTests : SchooxTest
    {
        private Exams _exams;
        public static TestContext Context { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Context = context;
        }

        [TestInitializeAttribute]
        public void Initialize()
        {
            _exams = new Exams(new SchooxService("schoox", 386));
        }

        [TestMethod()]
        public void GetExamsTest()
        {
            var response = _exams.GetExams();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Exams returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetEnrolledUsersInExamTest()
        {
            var response = _exams.GetEnrolledUsersInExam(169);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Users returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetExamPerformanceForUserTest()
        {
            var response = _exams.GetExamPerformanceForUser(169, 14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsNotNull(response.Data);

            Context.WriteLine("Performance Returned {0}", response.Data.ToString());
           
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }
    }
}
