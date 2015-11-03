using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchooxSharp.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchooxSharp.Api.Models;

namespace SchooxSharp.ApiTests
{
    [TestClass()]
    public class UsersTests : SchooxTest
    {
        private Users _users;
        public static TestContext Context { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Context = context;
        }

        [TestInitializeAttribute]
        public void Initialize()
        {
            _users = new Users(new SchooxService("schoox", 386));
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            var response = _users.GetUsers(Roles.Employee);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Users returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void GetDetailsOfUserTest()
        {
            var response = _users.GetDetailsOfUser(14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);

            Context.WriteLine("User returned {0}", response.Data);
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void CreateAndAddUserTest()
        {
            var user = GetBillV1();
            var response = _users.CreateAndAddUser(user);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        private static NewUser GetBillV1()
        {
            return new NewUser("BillTest4", "Lolos5", "123456", "graecus84@yahoo.gr",
                new List<string> { Roles.Employee }, new List<int> { 18 }, new List<int> { 4 },
                new List<NewUser.NewUserJob>
                {
                    new NewUser.NewUserJob(4, null, 2455),
                    new NewUser.NewUserJob(null, 18, 1)
                }, "English");
        }

        private static NewUser GetBillV2()
        {
            return new NewUser("Bill", "Lolos", null, "graecus84@yahoo.gr", new List<string> {Roles.Employee},
                new List<int> {1}, new List<int> {4}, new List<int> {1, 4});
        }

        [TestMethod()]
        public void BulkCreateAndAddUsersTest()
        {
            var users = new List<NewUser>
            {
                GetBillV2()
            };

            var response = _users.BulkCreateAndAddUsers(users);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void InviteUserTest()
        {
            var user = GetBillV2();

            var response = _users.InviteUser(user);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void BulkInviteUsersTest()
        {
            var users = new List<NewUser> {GetBillV2()};
            var response = _users.BulkInviteUsers(users);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void EditUserTest()
        {
            var user = new NewUser("John", "Doe", "pwd", "johndoe@schoox.com", null, null, null, null, null);
            var response = _users.EditUser(1234567890, user);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void RemoveUserTest()
        {
            var response = _users.RemoveUser(14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void ReactivateUserTestId()
        {
            var response = _users.ReactivateUser(3);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void ReactivateUserTestExternalId()
        {
            var response = _users.ReactivateUser("1001417");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void AddNewJobTest()
        {
            var response = _users.AddNewJob(new NewJob {Name = "API Developer", ReportId = 4945});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void BulkAddNewJobsTest()
        {
            var response = _users.BulkAddNewJobs(new List<NewJob>
            {
                new NewJob { Name = "API Developer" },
                new NewJob { Name = "API Evangelist", ReportId = 5}
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void EditJobTest()
        {
            var response = _users.EditJob(4945, new NewJob {Name = "API Developer"});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void DeleteJobTest()
        {
            var response = _users.DeleteJob(230);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod()]
        public void GetJobsTest()
        {
            var response = _users.GetJobs();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Jobs returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod()]
        public void UpdateUserRolesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUserJobsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddUnitsToUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveUnitsFromUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddAboveUnitsToUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveAboveUnitFromUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddNewTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BulkAddNewTypesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTypesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddNewAboveUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BulkAddNewAboveUnitsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditAboveUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAboveUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAboveUnitsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddNewUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BulkAddNewUnitsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ListUnitsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ArchiveUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UnarchiveUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteArchivedUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArchivedUnitsTest()
        {
            Assert.Fail();
        }
    }
}
