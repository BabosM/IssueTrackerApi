
namespace IssueTrackerSdk.ClientFactory
{  
    public class ConsoleHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            HttpClient httpClient = new HttpClient();
            return httpClient;
        }

    }
}


