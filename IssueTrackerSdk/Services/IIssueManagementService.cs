using IssueTrackerSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerSdk.Services
{
    public interface IIssueManagementService
    {
        Task AddIssue(string owner, string repository, string title, string body);
        Task ModifyIssue(string owner, string repository, int issueNumber, string title, string body);
        Task CloseIssue(string owner, string repository, int issueNumber);
        Task<List<Issue>> GetIssues(string owner, string repository);
        Task ExportIssuesToFile(string owner, string repository, string filePath);
        Task ImportIssuesFromFile(string owner, string repository, string filePath);
    }
}
