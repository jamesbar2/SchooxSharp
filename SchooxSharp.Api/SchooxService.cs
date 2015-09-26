using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SchooxSharp.Api
{
	public class SchooxService : ISchooxService
	{
		public SchooxService ()
		{
			InitializeDefaults ();
		}

		public SchooxService (string apiKey, int academyId)
		{
			ApiKey = apiKey;
			AcademyId = academyId;

			InitializeDefaults ();
		}

		private void InitializeDefaults()
		{
			//TODO: Load this from a configuration file
			BaseUrl = "https://www.schoox.com/api/v1";
		}

		#region ISchooxService implementation

		public Uri BuildUri (string path, bool requiresApiAuthentication = true)
		{
			return BuildUri (path, null, true);
		}

		/// <summary>
		/// Assists building the request URI
		/// </summary>
		/// <returns>The URI.</returns>
		/// <param name="path">Path.</param>
		/// <param name="queries">Queries.</param>
		public Uri BuildUri (string path, Dictionary<string, object> queries, bool requiresApiAuthentication = true)
		{
			//check internally to make sure the BaseUrl for the API is set
			if (string.IsNullOrWhiteSpace (BaseUrl))
				throw new ArgumentNullException ("BaseUrl", "The base URL is not set, or is invalid.");

			if (requiresApiAuthentication) {
				if (string.IsNullOrWhiteSpace (ApiKey))
					throw new ArgumentNullException ("ApiKey", "You must provide an API key for this function. Check the configuration file.");

				//this must be modified if Academy ID is ever not required as part of the authentication process
				if (AcademyId == null && AcademyId <= 0)
					throw new ArgumentException ("AcademyId", "You must provide an Academy ID for this function.  Check the configuration file.");
			}

			var sb = new StringBuilder ();

			sb.Append (BaseUrl);

			//check to see if the path and base url will be separated, if not, add a slash
			if (!BaseUrl.EndsWith ('/') && !path.StartsWith ('/'))
				sb.Append ('/');

			sb.Append (path);
			sb.Append ('?');

			if (requiresApiAuthentication) {
				sb.AppendFormat ("apikey={0}&acadId={1}&", ApiKey, AcademyId);
			}

			//check to see if theres anything to be added to the query string
			if (queries != null && queries.Any ()) {
				foreach (var item in queries) {
					

					//using the WebUtility class, can't guarantee this will be running on a system that has System.Web.HttpUtility.
					sb.AppendFormat ("{0}={1}&", item.Key, WebUtility.UrlEncode (item.Value));
				}
			}

			return new Uri (sb.ToString ());
		}

		public string ApiKey { get; private set; }
		public int AcademyId { get; private set; }
		public string BaseUrl  { get; private set;	}

		#endregion
	}
}

