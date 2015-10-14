using System;
using System.Collections.Generic;
using RestSharp;

namespace SchooxSharp.Api
{
    public interface ISchooxService
    {
        RestRequest GenerateBaseRequest(string requestPath, bool authenticate = true);
        RestClient SchooxRestClient { get; set; } 

        //string ApiKey {get; set;}
        //int AcademyId {get; set;}
        //string BaseUrl {get; set;}

        //Uri BuildUri(string path,  Dictionary<string, object> queries, bool requiresApiAuthentication = true);
    }
}

