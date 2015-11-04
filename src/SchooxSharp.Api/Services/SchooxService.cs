using System.Configuration;
using RestSharp;
using SchooxSharp.Api.Helpers;

namespace SchooxSharp.Api.Services
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
			ApiKey = ConfigurationManager.AppSettings["SchooxSharp.ApiKey"];

		    var acadId = 0;
		    if (int.TryParse(ConfigurationManager.AppSettings["SchooxSharp.AcademyId"], out acadId))
		        AcademyId = acadId;

		    BaseUrl = ConfigurationManager.AppSettings["SchooxSharp.BaseUrl"];

            if(string.IsNullOrWhiteSpace(BaseUrl))
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

    }
}

