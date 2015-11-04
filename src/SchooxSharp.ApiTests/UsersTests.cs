using System.Collections.Generic;
using System.Linq;
using SchooxSharp.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchooxSharp.Api.Constants;
using SchooxSharp.Api.Models;

namespace SchooxSharp.ApiTests
{
    [TestClass]
    public class UsersTests : SchooxTest
    {
        /// <summary>
        /// Method prefixes all create/edit/delete functions to globally disable 
        /// them with an "ignore" if the test framework is unstable at Schoox.
        /// </summary>
        private static void CanDoEdits()
        {
            //disable the following line to enable unit tests on create/edit/delete functions
            Assert.Inconclusive("Editing currently disabled.");
        }

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

        [TestMethod]
        public void GetUsersTest()
        {
            var response = _users.GetUsers(Roles.SchooxInternalEmployee);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Users returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod]
        public void GetDetailsOfUserTest()
        {
            var response = _users.GetDetailsOfUser(14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);

            Context.WriteLine("User returned {0}", response.Data);
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod]
        public void CreateAndAddUserTest()
        {
            CanDoEdits();

            var user = GetBillV1();
            var response = _users.CreateAndAddUser(user);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        private static NewUser GetBillV1()
        {
            return new NewUser("BillTest4", "Lolos5", "123456", "graecus84@yahoo.gr",
                new List<string> { Roles.SchooxInternalEmployee }, new List<int> { 18 }, new List<int> { 4 },
                new List<NewUser.NewUserJob>
                {
                    new NewUser.NewUserJob(4, null, 2455),
                    new NewUser.NewUserJob(null, 18, 1)
                }, "English");
        }

        private static NewUser GetBillV2()
        {
            return new NewUser("Bill", "Lolos", null, "graecus84@yahoo.gr", new List<string> {Roles.SchooxInternalEmployee},
                new List<int> {1}, new List<int> {4}, new List<int> {1, 4});
        }

        [TestMethod]
        public void BulkCreateAndAddUsersTest()
        {
            CanDoEdits();

            var users = new List<NewUser>
            {
                GetBillV2()
            };

            var response = _users.BulkCreateAndAddUsers(users);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void InviteUserTest()
        {
            CanDoEdits();

            var user = GetBillV2();

            var response = _users.InviteUser(user);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void BulkInviteUsersTest()
        {
            CanDoEdits();

            var users = new List<NewUser> {GetBillV2()};
            var response = _users.BulkInviteUsers(users);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void EditUserTest()
        {
            CanDoEdits();

            var user = new NewUser("John", "Doe", "pwd", "johndoe@schoox.com", null, null, null, null, null);
            var response = _users.EditUser(1234567890, user);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void RemoveUserTest()
        {
            CanDoEdits();

            var response = _users.RemoveUser(14);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void ReactivateUserTestId()
        {
            CanDoEdits();

            var response = _users.ReactivateUser(3);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void ReactivateUserTestExternalId()
        {
            CanDoEdits();

            var response = _users.ReactivateUser("1001417");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void AddNewJobTest()
        {
            CanDoEdits();

            var response = _users.AddNewJob(new NewJob {Name = "API Developer", ReportId = 4945});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void BulkAddNewJobsTest()
        {
            CanDoEdits();

            var response = _users.BulkAddNewJobs(new List<NewJob>
            {
                new NewJob { Name = "API Developer" },
                new NewJob { Name = "API Evangelist", ReportId = 5}
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void EditJobTest()
        {
            CanDoEdits();

            var response = _users.EditJob(4945, new NewJob {Name = "API Developer"});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void DeleteJobTest()
        {
            CanDoEdits();

            var response = _users.DeleteJob(230);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
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

        [TestMethod]
        public void UpdateUserRolesTest()
        {
            CanDoEdits();

            var response = _users.UpdateUserRoles(14, new List<string> {Roles.TrainingManager, Roles.SchooxInternalHourlyWorker});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void UpdateUserJobsTest()
        {
            CanDoEdits();

            var response = _users.UpdateUserJobs(14, new List<UpdateUserJob>
            {
                new UpdateUserJob(2002, null, 7160), 
                new UpdateUserJob(null, 636, 7158, 7156)
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void AddUnitsToUserTest()
        {
            CanDoEdits();

            var response = _users.AddUnitsToUser(14, new List<int> {4});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void RemoveUnitsFromUserTest()
        {
            CanDoEdits();

            var response = _users.RemoveUnitsFromUser(14, 35);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void AddAboveUnitsToUserTest()
        {
            CanDoEdits();

            var response = _users.AddAboveUnitsToUser(14, new List<int> { 11, 12});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void RemoveAboveUnitFromUserTest()
        {
            CanDoEdits();

            var response = _users.RemoveAboveUnitFromUser(14, 35);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void AddNewTypeTest()
        {
            CanDoEdits();

            var response = _users.AddNewType("Region");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);

        }

        [TestMethod]
        public void BulkAddNewTypesTest()
        {
            CanDoEdits();

            var response = _users.BulkAddNewTypes(new List<string>{"Region", "Contract"});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void EditTypeTest()
        {
            CanDoEdits();

            var response = _users.EditType(0, "Region");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void DeleteTypeTest()
        {
            CanDoEdits();

            var response = _users.DeleteType(0);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void GetTypesTest()
        {
            var response = _users.GetTypes();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Types returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod]
        public void AddNewAboveUnitTest()
        {
            CanDoEdits();

            var response = _users.AddNewAboveUnit(new AboveUnit {TypeId = 101, Name = "Region"});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void BulkAddNewAboveUnitsTest()
        {
            CanDoEdits();

            var response = _users.BulkAddNewAboveUnits(new List<AboveUnit>
            {
                new AboveUnit { TypeId = 6, Name = "Greece" },
                new AboveUnit { TypeId = 6, Name = "US"}
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void EditAboveUnitTest()
        {
            CanDoEdits();

            var response = _users.EditAboveUnit(20, new AboveUnit{Name = "United States"});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void DeleteAboveUnitTest()
        {
            CanDoEdits();

            var response = _users.DeleteAboveUnit(20);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void GetAboveUnitsTest()
        {
            var response = _users.GetAboveUnits();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            Assert.IsTrue(response.Data.Any());

            Context.WriteLine("Above Units returned {0}", response.Data.Count);
            foreach (var i in response.Data)
                Context.WriteLine(i.ToString());
            Context.WriteLine(FormatJsonForOutput(response.Response.Content));
        }

        [TestMethod]
        public void AddNewUnitTest()
        {
            CanDoEdits();

            var response = _users.AddNewUnit(new NewUnit {Name = "Austin", AboveIds = new List<int> {109}});

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void BulkAddNewUnitsTest()
        {
            CanDoEdits();

            var response = _users.BulkAddNewUnits(new List<NewUnit>
            {
                new NewUnit {Name = "Austin", AboveIds = new List<int> {109}},
                new NewUnit {Name = "Atlanta", AboveIds = new List<int> {85}}
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void EditUnitTest()
        {
            CanDoEdits();

            var response = _users.EditUnit(35, new NewUnit { AboveIds = new List<int> { 110 } });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void DeleteUnitTest()
        {
            CanDoEdits();

            var response = _users.DeleteUnit(35);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void GetUnitsTest()
        {
            var response = _users.GetUnits();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            if (response.Data != null)
            {
                Assert.IsTrue(response.Data.Any());

                Context.WriteLine("Archived Units returned {0}", response.Data.Count);
                foreach (var i in response.Data)
                    Context.WriteLine(i.ToString());
                Context.WriteLine(FormatJsonForOutput(response.Response.Content));
            }
            else
            {
                Context.WriteLine("Server response of \"{0}\"", FormatJsonForOutput(response.Response.Content));
            }
        }

        [TestMethod]
        public void ArchiveUnitTest()
        {
            CanDoEdits();

            var response = _users.ArchiveUnit(35);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void UnarchiveUnitTest()
        {
            CanDoEdits();

            var response = _users.UnarchiveUnit(35);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void DeleteArchivedUnitTest()
        {
            CanDoEdits();

            var response = _users.DeleteArchivedUnit(35);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
        }

        [TestMethod]
        public void GetArchivedUnitsTest()
        {
            var response = _users.GetArchivedUnits();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.RequestSuccessful, response.Response.ErrorMessage);
            if (response.Data != null)
            {
                Assert.IsTrue(response.Data.Any());

                Context.WriteLine("Archived Units returned {0}", response.Data.Count);
                foreach (var i in response.Data)
                    Context.WriteLine(i.ToString());
                Context.WriteLine(FormatJsonForOutput(response.Response.Content));
            }
            else
            {
                Context.WriteLine("Server response of \"{0}\"", FormatJsonForOutput(response.Response.Content));
            }
        }
    }
}
