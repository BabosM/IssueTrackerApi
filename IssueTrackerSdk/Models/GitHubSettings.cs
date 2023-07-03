using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerSdk.Models
{
    public class GitHubSettings
    {
        public string BaseUrl { get; set; }
        public string Token { get; set; }
        public string ApiVersion { get; set; }
    }
}
