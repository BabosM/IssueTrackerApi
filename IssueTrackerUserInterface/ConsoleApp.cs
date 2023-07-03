using IssueTrackerSdk.Factories;
using IssueTrackerSdk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerUserInterface
{
    public class ConsoleApp : IConsoleApp
    {
        private readonly IIssueManagementServiceFactory _issueManagementServiceFactory;

        public ConsoleApp(IIssueManagementServiceFactory issueManagementServiceFactory)
        {
            _issueManagementServiceFactory = issueManagementServiceFactory;
        }
        public void Run()
        {
            Console.WriteLine("Wybierz repozytorium:");
            Console.WriteLine("1. GitHub");
            Console.WriteLine("2. Bitbucket");

            string choice = Console.ReadLine();

            IIssueManagementService issueManagementService;
            var exit = false;
            while (!exit)
            {
                switch (choice)
                {
                    case "1":
                        issueManagementService = _issueManagementServiceFactory.CreateService("GitHub");
                        break;
                    case "2":
                        issueManagementService = _issueManagementServiceFactory.CreateService("Bitbucket");
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór.");
                        return;
                }

                Console.WriteLine("Wybierz operację:");
                Console.WriteLine("1. Dodaj problem");
                Console.WriteLine("2. Modyfikuj problem");
                Console.WriteLine("3. Zamknij problem");
                Console.WriteLine("4. Pobierz problemy");
                Console.WriteLine("5. Eksportuj problemy do pliku");
                Console.WriteLine("6. Importuj problemy z pliku");
                Console.WriteLine("7. Zakończ program");
                string operationChoice = Console.ReadLine();

                switch (operationChoice)
                {
                    case "1":
                        Console.WriteLine("Podaj nazwę problemu:");
                        string issueName = Console.ReadLine();

                        Console.WriteLine("Podaj opis problemu:");
                        string issueDescription = Console.ReadLine();

                        Console.WriteLine("Podaj właściciela repozytorium:");
                        string owner = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę repozytorium:");
                        string repository = Console.ReadLine();

                        issueManagementService.AddIssue(owner, repository, issueName, issueDescription).Wait();

                        Console.WriteLine("Problem został dodany.");
                        break;
                    case "2":
                        Console.WriteLine("Podaj właściciela repozytorium:");
                        string ownerToModify = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę repozytorium:");
                        string repositoryToModify = Console.ReadLine();

                        Console.WriteLine("Podaj identyfikator problemu:");
                        int issueIdToModify = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Podaj nową nazwę problemu:");
                        string newIssueName = Console.ReadLine();

                        Console.WriteLine("Podaj nowy opis problemu:");
                        string newIssueDescription = Console.ReadLine();

                        issueManagementService.ModifyIssue(ownerToModify, repositoryToModify, issueIdToModify, newIssueName, newIssueDescription).Wait();

                        Console.WriteLine("Problem został zmodyfikowany.");
                        break;
                    case "3":
                        Console.WriteLine("Podaj właściciela repozytorium:");
                        string ownerToClose = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę repozytorium:");
                        string repositoryToClose = Console.ReadLine();

                        Console.WriteLine("Podaj identyfikator problemu:");
                        int issueIdToClose = Convert.ToInt32(Console.ReadLine());

                        issueManagementService.CloseIssue(ownerToClose, repositoryToClose, issueIdToClose).Wait();

                        Console.WriteLine("Problem został zamknięty.");
                        break;
                    case "4":
                        Console.WriteLine("Podaj właściciela repozytorium:");
                        string ownerToGet = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę repozytorium:");
                        string repositoryToGet = Console.ReadLine();

                        var issues = issueManagementService.GetIssues(ownerToGet, repositoryToGet).Result;

                        Console.WriteLine("Pobrane problemy:");
                        foreach (var issue in issues)
                        {
                            Console.WriteLine($"Id: {issue.Id}, Nazwa: {issue.Name}, Opis: {issue.Description}");
                        }

                        break;
                    case "5":
                        Console.WriteLine("Podaj właściciela repozytorium:");
                        string ownerToExport = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę repozytorium:");
                        string repositoryToExport = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę pliku:");
                        string exportFileName = Console.ReadLine();

                        issueManagementService.ExportIssuesToFile(ownerToExport, repositoryToExport, exportFileName).Wait();

                        Console.WriteLine("Problemy zostały wyeksportowane do pliku.");
                        break;
                    case "6":
                        Console.WriteLine("Podaj właściciela repozytorium:");
                        string ownerToImport = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę repozytorium:");
                        string repositoryToImport = Console.ReadLine();

                        Console.WriteLine("Podaj nazwę pliku:");
                        string importFileName = Console.ReadLine();

                        issueManagementService.ImportIssuesFromFile(ownerToImport, repositoryToImport, importFileName).Wait();

                        Console.WriteLine("Problemy zostały zaimportowane z pliku.");
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("Program zakończony.");
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór operacji.");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
