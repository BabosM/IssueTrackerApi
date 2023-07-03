using IssueTrackerSdk.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerSdk.Services
{
    public class BitbucketIssueManagementService : IIssueManagementService
    {
        public BitbucketIssueManagementService(HttpClient httpClient, IConfiguration configuration)
        {
        }
        public Task AddIssue(string owner, string repository, string title, string body)
        {
            throw new NotImplementedException();
        }

        public Task CloseIssue(string owner, string repository, int issueNumber)
        {
            throw new NotImplementedException();
        }

        public Task ExportIssuesToFile(string owner, string repository, string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<List<Issue>> GetIssues(string owner, string repository)
        {
            throw new NotImplementedException();
        }

        public Task ImportIssuesFromFile(string owner, string repository, string filePath)
        {
            throw new NotImplementedException();
        }

        public Task ModifyIssue(string owner, string repository, int issueNumber, string title, string body)
        {
            throw new NotImplementedException();
        }
    }
}
