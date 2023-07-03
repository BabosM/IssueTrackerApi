using IssueTrackerSdk.Extensions;
using IssueTrackerSdk.Models;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace IssueTrackerSdk.Services
{
    public class GitHubIssueManagementService : IIssueManagementService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl;
        public GitHubIssueManagementService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            baseUrl = configuration["GitHubSettings:BaseUrl"];
            _httpClient = httpClient.AddBitbuckietAuthentication(configuration);

        }
        public async Task AddIssue(string owner, string repository, string name, string description)
        {
            var requestBody = new
            {
                title = name,
                body = description
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{baseUrl}/repos/{owner}/{repository}/issues", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to add issue. Status code: " + response.StatusCode);
                return;
            }

            Console.WriteLine("Issue added successfully.");
        }

        public async Task ModifyIssue(string owner, string repository, int issueId, string name, string description)
        {
            var requestBody = new
            {
                title = name,
                body = description
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync($"{baseUrl}/{owner}/{repository}/issues/{issueId}", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to modify issue. Status code: " + response.StatusCode);
                return;
            }

            Console.WriteLine("Issue modified successfully.");
        }

        public async Task CloseIssue(string owner, string repository, int issueId)
        {
            var requestBody = new
            {
                state = "closed"
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync($"{baseUrl}/{owner}/{repository}/issues/{issueId}", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to close issue. Status code: " + response.StatusCode);
                return;
            }

            Console.WriteLine("Issue closed successfully.");
        }

        public async Task<List<Issue>> GetIssues(string owner, string repository)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/repos/{owner}/{repository}/issues");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to retrieve issues. Status code: " + response.StatusCode);
                return new List<Issue>();
            }

            var json = response.Content.ReadAsStringAsync().Result;
            var issues = JsonSerializer.Deserialize<List<Issue>>(json);

            return issues;
        }

        public async Task ExportIssuesToFile(string owner, string repository, string filePath)
        {
            var issues = await GetIssues(owner, repository);
            var json = JsonSerializer.Serialize(issues);

            File.WriteAllText(filePath, json);

            Console.WriteLine("Issues exported to file successfully.");
        }

        public async Task ImportIssuesFromFile(string owner, string repository, string filePath)
        {
            var json = File.ReadAllText(filePath);
            var issues = JsonSerializer.Deserialize<List<Issue>>(json);

            foreach (var issue in issues)
            {
                await AddIssue(owner, repository, issue.Name, issue.Description);
            }

            Console.WriteLine("Issues imported from file successfully.");
        }
    }
}
