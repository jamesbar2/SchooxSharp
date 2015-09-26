using System;
using System.Collections.Generic;

namespace SchooxSharp.Api
{
	public interface ISchooxService
	{
		string ApiKey {get; set;}
		int AcademyId {get; set;}

		string BaseUrl {get; set;}

		Uri BuildUri(string path,  Dictionary<string, object> queries, bool requiresApiAuthentication = true);
		


	}
}

