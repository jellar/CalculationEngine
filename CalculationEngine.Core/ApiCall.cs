using System.Net;

namespace CalculationEngine.Core
{
    public static class ApiCall
    {
        private const string baseUrl = "http://api.mathjs.org/v4/";

        public static string GetExpressionResult(string expression)
        {
            var url = $"{baseUrl}?expr={expression}";
            using var client = new WebClient();
            var response = client.DownloadString(url);
            return !string.IsNullOrEmpty(response) ? response : string.Empty;
        }
    }
}
