using IssueTrackerSdk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerSdk.Factories
{
    public interface IIssueManagementServiceFactory
    {
        IIssueManagementService CreateService(string serviceType);
    }
}
