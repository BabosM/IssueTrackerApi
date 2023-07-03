using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerSdk.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpClient AddGitHubAuthentication(this HttpClient httpClient, IConfiguration configuration)
        {
            var baseUrl = configuration["GitHubSettings:BaseUrl"];
            var token = configuration["GitHubSettings:Token"];
            var apiVersion = configuration["GitHubSettings:ApiVersion"];

            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", apiVersion);

            return httpClient;
        }
        public static HttpClient AddBitbuckietAuthentication(this HttpClient httpClient, IConfiguration configuration)
        {
            var baseUrl = configuration["GitHubSettings:BaseUrl"];
            var token = configuration["GitHubSettings:Token"];
            var apiVersion = configuration["GitHubSettings:ApiVersion"];

            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", apiVersion);

            return httpClient;
        }
    }
}
