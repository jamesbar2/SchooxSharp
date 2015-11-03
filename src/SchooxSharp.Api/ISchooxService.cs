using RestSharp;

namespace SchooxSharp.Api
{
    public interface ISchooxService
    {
        RestRequest GenerateBaseRequest(string requestPath, bool authenticate = true);
        RestClient SchooxRestClient { get; set; } 
    }
}

