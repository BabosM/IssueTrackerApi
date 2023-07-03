using IssueTrackerSdk.ClientFactory;
using IssueTrackerSdk.Factories;
using IssueTrackerUserInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
                        .AddSingleton<IConfiguration>(provider => new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build())
                        .AddSingleton<IHttpClientFactory, ConsoleHttpClientFactory>()
                        .AddSingleton<IIssueManagementServiceFactory, IssueManagementServiceFactory>()
                        .AddSingleton<IConsoleApp, ConsoleApp>()
                        .BuildServiceProvider();

        var consoleApp = serviceProvider.GetService<IConsoleApp>();
        consoleApp.Run();

        Console.ReadLine();
    }
}