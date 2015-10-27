namespace SchooxSharp.ApiTests
{
    public class SchooxTest
    {
        public string FormatJsonForOutput(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? string.Empty : json.Replace("{", "{{").Replace("}", "}}");
        }
    }
}