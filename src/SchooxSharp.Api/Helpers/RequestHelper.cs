using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace SchooxSharp.Api.Helpers
{
    public static class RequestHelper
    {
        public static void AddAuthentication(this RestRequest request, string apiKey, int academyId)
        {
            request.AddQueryParameter("apikey", apiKey);
            request.AddQueryParameter("acadId", academyId.ToString(CultureInfo.InvariantCulture));
        }

        public static void AddNonBlankQueryString(this RestRequest request, string key, string value)
        {
            if(!string.IsNullOrWhiteSpace(value))
                request.AddQueryParameter(key, value);
        }

        public static void AddNonBlankQueryString(this RestRequest request, string key, object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                request.AddQueryParameter(key, value.ToString());
        }


        public static void AddNonBlankParameter(this RestRequest request, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                request.AddParameter(key, value);
        }

        public static void AddNonBlankParameter(this RestRequest request, string key, object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                request.AddParameter(key, value);
        }

        public static void SetJsonHandler(this RestRequest request)
        {
            request.JsonSerializer = new JsonNetSerializer();
        }
    }
}
