namespace SchooxSharp.Api.Tests.Clients
{
    public class SchooxTestBase
    {
        public string FormatJsonForOutput(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? string.Empty : json.Replace("{", "{{").Replace("}", "}}");
        }
    }
}