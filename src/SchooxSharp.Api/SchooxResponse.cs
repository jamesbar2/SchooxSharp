using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace SchooxSharp.Api
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
            get { return Response.Data; }
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
    }
}
