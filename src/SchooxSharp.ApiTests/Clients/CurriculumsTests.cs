﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchooxSharp.Api.Clients;
using SchooxSharp.Api.Services;

namespace SchooxSharp.Api.Tests.Clients
{
    [TestClass()]
    public class CurriculumsTestsBase : SchooxTestBase
    {
        private Curriculums _curriculums;
        public static TestContext Context { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Context = context;
        }

        [TestInitialize]
        public void Initialize()
        {
            _curriculums = new Curriculums(new SchooxService("schoox", 386));
        }

        [TestMethod()]
        public void GetCurriculumsTest()
        {
            var response = _curriculums.GetCurriculums();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Curriculums returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetUsersCurriculumsTest()
        {
            var response = _curriculums.GetUsersCurriculums(14);
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Curriculums returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
        }

        [TestMethod()]
        public void GetDetailsForCurriculumTest()
        {
            var response = _curriculums.GetDetailsForCurriculum(37);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Context.WriteLine("Curriculums returned {0}", response.Data);
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }
    }
}
