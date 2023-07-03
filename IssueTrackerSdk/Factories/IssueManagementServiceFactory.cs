using IssueTrackerSdk.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerSdk.Factories
{
    public class IssueManagementServiceFactory : IIssueManagementServiceFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public IssueManagementServiceFactory(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public IIssueManagementService CreateService(string serviceType)
        {
            // Tworzenie odpowiedniej instancji IIssueManagementService na podstawie parametru serviceType
            // Można tutaj zastosować instrukcję switch lub inne metody identyfikacji serwisu
            // i zwrócić odpowiednią implementację serwisu

            if (serviceType == "GitHub")
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();
                return new GitHubIssueManagementService(httpClient, _configuration);
            }
            else if (serviceType == "Bitbucket")
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();
                return new BitbucketIssueManagementService(httpClient, _configuration);
            }
            // Dodaj inne przypadki dla innych serwisów hostingowych

            throw new ArgumentException("Invalid service type.");
        }
    }
 }
