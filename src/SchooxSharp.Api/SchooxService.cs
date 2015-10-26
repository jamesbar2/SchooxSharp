using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Net;
using RestSharp;
using RestSharp.Deserializers;
using SchooxSharp.Api.Helpers;

namespace SchooxSharp.Api
{
	public class SchooxService : ISchooxService
	{
        public RestClient SchooxRestClient { get; set; }
        public string ApiKey { get; set; }
        public int AcademyId { get; set; }
        public string BaseUrl { get; set; }

		public SchooxService ()
		{
			InitializeDefaults ();
		}

		public SchooxService (string apiKey, int academyId)
		{
			InitializeDefaults ();

            ApiKey = apiKey;
            AcademyId = academyId;
		}

		private void InitializeDefaults()
		{
			//TODO: Load this from a configuration file
			BaseUrl = "https://www.schoox.com/api/v1";
            SchooxRestClient = new RestClient(BaseUrl);
		}

	    public RestRequest GenerateBaseRequest(string requestPath, bool authenticate = true)
	    {
            var request = requestPath == null ? new RestRequest() : new RestRequest(requestPath);
	        request.SetJsonHandler();
            if (authenticate) request.AddAuthentication(ApiKey, AcademyId);
	        return request;
	    }

/*
		#region ISchooxService implementation

		public Uri BuildUri (string path, bool requiresApiAuthentication = true)
		{
			return BuildUri (path, null);
		}

	    /// <summary>
	    /// Assists building the request URI
	    /// </summary>
	    /// <returns>The URI.</returns>
	    /// <param name="path">Path.</param>
	    /// <param name="queries">Queries.</param>
	    /// <param name="requiresApiAuthentication">Does the command require authentication</param>
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
			if (!BaseUrl.EndsWith ("/") && !path.StartsWith ("/"))
				sb.Append ('/');

			sb.Append (path);

			if (requiresApiAuthentication) {
				sb.AppendFormat ("?apikey={0}&acadId={1}&", ApiKey, AcademyId);
			}
            else if (queries.Any())
                sb.Append('?');

			//check to see if theres anything to be added to the query string
	        if (queries == null || !queries.Any()) return new Uri(sb.ToString());
	        
            foreach (var item in queries) {
	            //using the WebUtility class, this can be changed if using  
	            sb.AppendFormat ("{0}={1}&", item.Key, UrlEncodeValue(item.Value));
	        }

	        return new Uri (sb.ToString ());
		}

        /// <summary>
        /// Provides simple functionality to encode a string for use in the URL.
        /// This can be modified based on what version of the .NET framework you're using.
        /// </summary>
        /// <param name="item">Object to be encoded</param>
        /// <returns>Encoded object.</returns>
	    private static string UrlEncodeValue(object item)
        {
            //return HttpUtility.UrlEncode(item.ToString());    //for use in web project
	        return WebUtility.UrlEncode(item.ToString());       //for use in .NET >4.5
	    }

		public string ApiKey { get; private set; }
		public int AcademyId { get; private set; }
		public string BaseUrl  { get; private set;	}

		#endregion

        string ISchooxService.ApiKey
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        int ISchooxService.AcademyId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string ISchooxService.BaseUrl
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Uri ISchooxService.BuildUri(string path, Dictionary<string, object> queries, bool requiresApiAuthentication)
        {
            throw new NotImplementedException();
        }*/
    }
}

