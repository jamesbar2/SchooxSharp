using RestSharp;

namespace SchooxSharp.Api.Services
{
    public interface ISchooxService
    {
        RestRequest GenerateBaseRequest(string requestPath, bool authenticate = true);
        RestClient SchooxRestClient { get; set; } 
    }
}

