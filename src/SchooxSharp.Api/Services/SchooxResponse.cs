using System.Net;
using RestSharp;

namespace SchooxSharp.Api.Services
{
    /// <summary>
    /// Generic SchooxResponse from a request without Data.
    /// </summary>
    public abstract class SchooxResponseBase
    {
 
        /// <summary>
        /// The HTTP status code from the request.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The URI the request was made to.  Also useful for debugging if there are issues.
        /// </summary>
        public string RequestUrl { get; set; }

    }

    /// <summary>
    /// SchooxResponse from a request that expects data.
    /// </summary>
    /// <typeparam name="T">Type expected to be returned by the request.</typeparam>
    public class SchooxResponse<T> : SchooxResponseBase
    {
        public IRestResponse<T> Response { get; set; }
        
        public SchooxResponse(IRestResponse<T> response)
        {
            Response = response;

            StatusCode = response.StatusCode;
            RequestUrl = response.Request.Resource;
        }

        /// <summary>
        /// T type of data returned from the response.
        /// </summary>
        public T Data
        {
            get
            {
                if (Response.Data == null)
                    return default(T);
                return Response.Data;
            }
        }

        public bool RequestSuccessful
        {
            get
            {
                if (Response.ErrorException != null && Response.Content != "null")
                    return false;

                switch (Response.Request.Method)
                {
                    case Method.GET:
                        return Response.StatusCode == HttpStatusCode.OK;
                    case Method.POST:
                        return Response.StatusCode == HttpStatusCode.Created;
                    case Method.PUT:
                    case Method.DELETE:
                        return Response.StatusCode == HttpStatusCode.NoContent;
                }

                return false;
            }
        }

        public bool HasResponseError
        {
            get { return Response.ErrorException != null; }

        }
    }

    public class SchooxResponse : SchooxResponseBase
    {
        public IRestResponse Response { get; set; }

        public SchooxResponse(IRestResponse response)
        {
            Response = response;

            StatusCode = response.StatusCode;
            RequestUrl = response.Request.Resource;
        }

        public bool RequestSuccessful
        {
            get
            {
                if (Response.ErrorException != null)
                    return false;


                switch (Response.Request.Method)
                {
                    case Method.GET:
                        return Response.StatusCode == HttpStatusCode.OK;
                    case Method.POST:
                        return Response.StatusCode == HttpStatusCode.Created;
                    case Method.PUT:
                    case Method.DELETE:
                        return Response.StatusCode == HttpStatusCode.NoContent;
                }

                return false;
            }
        }

        public bool HasResponseError
        {
            get { return Response.ErrorException != null; }

        }

    }
}
