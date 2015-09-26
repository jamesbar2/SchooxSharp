using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchooxSharp.Api.Helpers;

namespace SchooxSharp.Api
{
    /// <summary>
    /// The following requests relate to getting information about users' training 
    /// performance from different points of view via the Schoox Academy API. 
    /// Note: All requests must be Authenticated. Access Level for all requests: 
    /// Administrators, Training Managers, Region and Location Managers. Depending 
    /// on the role the requests return data either for all users (Access level: 
    /// Administrators and Training Managers) or for users that belong to a certain 
    /// region or location (Access Level: Region Managers, Local Managers). 
    /// You can simulate a user's view by his/her schooX ID.
    /// </summary>
    public class Dashboard
    {
		public ISchooxService SService { get; set; }

		public Dashboard(ISchooxService service) 
		{
			SService = service;
		}

		public Dashboard()
		{
			SService = new SchooxService ();
		}

		/// <summary>
		/// Returns a list of current users in your organization with a summary of 
		/// their training performance (e.g. total training hours, courses and exams). 
		/// By default only the first 100 people are returned. The list can be 
		/// filtered on letter, role, region and location and paged using the 
		/// optional paging parameters.
		/// </summary>
		/// <returns>A list of current users in your organization with a summary of their training performance</returns>
		/// <param name="role">Users' role</param>
		/// <param name="userId">User Id to be simulated as logged in user</param>
		/// <param name="externalId">Sets whether the id given is the external_id of the User. By default, the value is "false"</param>
		/// <param name="aboveId">Above Unit's ID</param>
		/// <param name="unitId">Unit's ID</param>
		/// <param name="jobId">Job's ID</param>
		/// <param name="start">List's starting position</param>
		/// <param name="limit">Number of users to return per request, up to maximum of 1,000. Default to 100</param>
		/// <param name="sort">Sorting criteria</param>
        public List<object> GetUsers(string role, int? userId = null, string externalId = null, 
			int? aboveId = null, int? unitId = null, int? jobId = null, int? start = null, 
			int? limit = 100, string sort = null)
		{
			//TODO: Validation

			//GET /dashboard/users
			var path = "/dashboard/users";

			var db = new DictionaryQueryBuilder();
			db.Add ("role", role);
			db.Add ("userId", userId);
			db.Add ("external_id", externalId);
			db.Add ("aboveId", aboveId);
			db.Add ("unitId", unitId);
			db.Add ("jobId", jobId);
			db.Add ("start", start);
			db.Add ("limit", limit);
			db.Add ("sort", sort);


			throw new NotImplementedException ();
		}

		/// <summary>
		/// Returns a list of all courses a user is enrolled in with a summary of 
		/// his or her total training and training information by course (e.g. 
		/// enrollment/assignment date, due date, total time spent on the course and 
		/// progress). By default only the first 100 people are returned.
		/// </summary>
		/// <returns>A list of all courses a user is enrolled in with a summary of his or 
		/// her total training and training information by course</returns>
		/// <param name="userId">User identifier.</param>
		/// <param name="externalId">Sets whether the id given is the external_id of the User.  By default, the value is "false"</param>
		public List<object> GetUserCourses(int userId, string externalId = null)
		{
			//TODO: Validation

			//GET /dashboard/users/:userid/courses
			var path = string.Format("/dashboard/users/{0}/courses", userId);

			if (externalId != null) {
				var db = new DictionaryQueryBuilder ();
				db.Add ("external_id", externalId);
			}
		
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Returns a list of all curriculums a user is enrolled in with a summary of his 
		/// or her total training and training information by curriculum (e.g. 
		/// enrollment/assignment date, due date, total time spent on the curriculum 
		/// and progress). By default only the first 100 people are returned.
		/// </summary>
		/// <returns>List of all curriculums a user is enrolled in with a summary of his 
		/// or her total training and training information by curriculum</returns>
		/// <param name="userId">User identifier.</param>
		/// <param name="externalId">Sets whether the id given is the external_id of the User.  
		/// By default, the value is "false"</param>
		public List<object> GetUserCurriculums(int userId, string externalId = null)
		{
			//TODO: Validation
		
			//GET /dashboard/users/:userid/courses
			var path = string.Format("/dashboard/users/{0}/courses", userId);

			if (externalId != null) {
				var db = new DictionaryQueryBuilder ();
				db.Add ("external_id", externalId);
			}


			throw new NotImplementedException ();
		}

		/// <summary>
		/// Returns a list of all exams a user has taken so far with information about his 
		/// or her performance on every exam (e.g. number of attempts, date of last attempt, 
		/// score, points, passing score). By default only the first 100 people are returned.
		/// </summary>
		/// <returns>List of all exams a user has taken so far with information about his 
		/// or her performance on every exam</returns>
		/// <param name="userId">User identifier.</param>
		/// <param name="externalId">Sets whether the id given is the external_id of the User.  
		/// By default, the value is "false"</param>
		public List<object> GetUserExams(int userId, string externalId = null)
		{
			//TODO: Validation

			//GET /dashboard/users/:userid/courses
			var path = string.Format("/dashboard/users/:userid/courses", userId);

			if (externalId != null) {
				var db = new DictionaryQueryBuilder ();
				db.Add ("external_id", externalId);
			}

			throw new NotImplementedException ();
		}

		/// <summary>
		/// Returns a list of all courses with title, short description and image.
		/// </summary>
		/// <returns>List of all courses with title, short description and image.</returns>
		/// <param name="role">User's role.</param>
		public List<object> GetCourses(string role)
		{
			//TODO: Validation

			//GET /dashboard/courses
			var path = "/dashboard/courses";

			var db = new DictionaryQueryBuilder ();
			db.Add ("role", role);

			throw new NotImplementedException ();
		}

		/// <summary>
		/// Returns a list of enrolled users in a course with a summary of information for every 
		/// user (e.g. enrollment date, user’s region and location, total time spent on course 
		/// and total progress).
		/// </summary>
		/// <returns>The enrolled users in course.</returns>
		/// <param name="courseId">Course identifier.</param>
		/// <param name="role">User's role</param>
		/// <param name="regionId">Region identifier.</param>
		/// <param name="locationId">Location identifier.</param>
		/// <param name="jobId">Job identifier.</param>
		/// <param name="letter">Lastname's starting letter</param>
		/// <param name="start">List's starting position</param>
		/// <param name="limit">Number of users to return per request, up to maximum of 1,000. Default to 100</param>
		/// <param name="sort">Sorting critera</param>
		public List<object> GetEnrolledUsersInCourse(int courseId, string role, int? regionId = null, 
			int? locationId = null, int jobId = null, string letter = null, int? start = null, 
			int? limit = 100, string sort = null)
		{
			//TODO: Validation

			//GET /dashboard/courses/:courseid
			var path = string.Format ("/dashboard/courses/{0}", courseId);

			var db = new DictionaryQueryBuilder();
			db.Add ("role", role);
			db.Add ("regionId", regionId);
			db.Add ("locationId", locationId);
			db.Add ("jobId", jobId);
			db.Add ("letter", letter);
			db.Add ("start", start);
			db.Add ("limit", limit);
			db.Add ("sort", sort);


			throw new NotImplementedException ();
		}

		/// <summary>
		/// Courses can consist of one or more lectures and exams. This request 
		/// returns detailed information about a user's progress on a course for 
		/// every single lecture and exam of it (e.g. lecture name, progress, time 
		/// spent, number of attempts, name of exam, score, date of last attempt).
		/// </summary>
		/// <returns>Detailed information about a user's progress on a course for 
		/// every single lecture and exam of it</returns>
		/// <param name="courseId">Course identifier.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="externalId">Sets whether the id given is the external_id of the User.
		/// By default, the value is "false"</param>
		public Tuple<object, object, object> GetDetailedCourseProgressForUser(int courseId, int userId, string externalId = null)
		{
			//TODO: Validation

			//GET /dashboard/courses/:courseid/users/:userid
			var path = string.Format("/dashboard/courses/{0}/users/{1}", courseId, userId);

			if (externalId != null) {
				var db = new DictionaryQueryBuilder ();
				db.Add ("external_id", externalId);
			}

			throw new NotImplementedException ();
		}

		/// <summary>
		/// Returns a list of all curriculums with title, short description, image and number of courses.
		/// </summary>
		/// <returns>A list of all curriculums with title, short description, image and number of courses</returns>
		/// <param name="role">Users' role</param>
		public List<object> GetCurriculums(string role)
		{
			//TODO: Validation

			//GET /dashboard/curriculums
			var path = "/dashboard/curriculums";

			var db = new DictionaryQueryBuilder ();
			db.Add ("role", role);

			throw new NotImplementedException ();
		}

		/// <summary>
		/// Returns a list of enrolled users in a curriculum with a summary of information for every user 
		/// (e.g. enrollment date, total time spent on the curriculum and total progress).
		/// </summary>
		/// <returns>A list of enrolled users in a curriculum with a summary of information for every user</returns>
		/// <param name="curriculumId">Curriculum identifier.</param>
		/// <param name="role">User's role</param>
		/// <param name="regionId">Region identifier.</param>
		/// <param name="locationId">Location identifier.</param>
		/// <param name="jobId">Job identifier.</param>
		/// <param name="letter">Lastname's starting letter</param>
		/// <param name="start">List's starting position</param>
		/// <param name="limit">Number of users to return per request, up to maximum of 1,000. Default to 100</param>
		/// <param name="sort">Sorting critera</param>
		public List<object> GetEnrolledUsersInCurriculum(int curriculumId, string role, int? regionId = null, 
			int? locationId = null, int? jobId = null, string letter = null, int? start = null,
			int? limit = null, string sort = null)
		{
			//TODO: Validation

			//GET /dashboard/curriculums/:curriculumid
			var path = string.Format ("/dashboard/curriculums/{0}", curriculumId);

			var db = new DictionaryQueryBuilder ();
			db.Add ("role", role);
			db.Add ("regionId", regionId);
			db.Add ("locationId", locationId);
			db.Add ("jobId", jobId);
			db.Add ("letter", letter);
			db.Add ("start", start);
			db.Add ("limit", limit);
			db.Add ("sort", sort);


			throw new NotImplementedException ();
		}

		/// <summary>
		/// Curriculums can consist of one or more courses. This request returns detailed information 
		/// about a user’s progress on a curriculum for every single course of it (e.g. course name, 
		/// image, time spent and total progress).
		/// </summary>
		/// <returns>Detailed information about a user’s progress on a curriculum for every single course of it</returns>
		/// <param name="curriculumId">Curriculum identifier.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="externalId">Sets whether the id given is the external_id of the User. 
		/// By default, the value is "false"</param>
		public object GetCurriculumProgressForUser(int curriculumId, int userId, string externalId = null)
		{
			//TODO: Validation

			//GET /dashboard/curriculums/:curriculumid/users/:userid
			var path = string.Format("/dashboard/curriculums/{0}/users/{1}", curriculumId, userId);

			if (externalId != null) {
				var db = new DictionaryQueryBuilder ();
				db.Add ("external_id", externalId);
			}

			throw new NotImplementedException ();
		}

		/// <summary>
		/// Returns a list of all exams with title, image and publishing date.
		/// </summary>
		/// <returns>List of all exams with title, image and publishing date</returns>
		/// <param name="role">User's role</param>
		public List<object> GetExams(string role)
		{
			//GET /dashboard/exams
			var path = "/dashboard/exams";

			var db = new DictionaryQueryBuilder ();
			db.Add ("role", role);


			throw new NotImplementedException ();
		}

		/// <summary>
		/// This returns a list of all users for an exam with detailed information about every user's 
		/// performance (e.g. user’s name, number of attempts, date of last attempt, starting date, 
		/// ending date, score, points and status: passed / failed).
		/// </summary>
		/// <returns>List of all users for an exam with detailed information about every user's performance.</returns>
		/// <param name="examId">Exam identifier.</param>
		/// <param name="role">User's role</param>
		/// <param name="regionId">Region identifier.</param>
		/// <param name="locationId">Location identifier.</param>
		/// <param name="jobId">Job identifier.</param>
		/// <param name="letter">Lastname's starting letter</param>
		/// <param name="start">List's starting position</param>
		/// <param name="limit">Number of users to return per request, up to maximum of 1,000. Default to 100</param>
		/// <param name="sort">Sorting critera</param>
		public List<object> GetEnrolledUsersInExam(int examId, string role, int? regionId = null, 
			int? locationId = null, int? jobId = null, string letter = null, int? start = null,
			int? limit = null, string sort = null)
		{
			//GET /dashboard/exams/:examid
			var path = string.Format ("/dashboard/exams/{0}", examId);

			var db = new DictionaryQueryBuilder ();
			db.Add ("role", role);
			db.Add ("regionId", regionId);
			db.Add ("locationId", locationId);
			db.Add ("jobId", jobId);
			db.Add ("letter", letter);
			db.Add ("start", start);
			db.Add ("limit", limit);
			db.Add ("sort", sort);

			throw new NotImplementedException ();
		}
    }
}