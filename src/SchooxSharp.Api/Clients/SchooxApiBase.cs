using RestSharp;
using SchooxSharp.Api.Services;

namespace SchooxSharp.Api.Clients
{
    public abstract class SchooxApiBase
    {
        public ISchooxService SService { get; set; }

        /// <summary>
        /// Executes the base request against the SchooxService Rest Client 
        /// </summary>
        /// <typeparam name="T">Type expected from response</typeparam>
        /// <param name="request">Request to be executed against the Rest Client</param>
        /// <returns>The SchooxResponse with the IRestResponse embedded</returns>
        public SchooxResponse<T> Execute<T>(RestRequest request) where T : new()
        {
            return new SchooxResponse<T>(SService.SchooxRestClient.Execute<T>(request));
        }

        public SchooxResponse Execute(RestRequest request)
        {
            return new SchooxResponse(SService.SchooxRestClient.Execute(request));
        }
    }
}