using GitAssistant.Git;
using GitAssistant.Models;
using GitAssistant.UI;

namespace GitAssistant.App;

public static class MenuService
{
    public static void ShowAndSelectOptions()
    {
        var gitService = new GitService();
        var writer = new ConsoleWriter();

        var options = new List<MenuOption> ([
            new MenuOption{ Id = "1", Title = "Show current branch", Action = () => writer.WriteGitStatus(gitService.RunGitCommand("branch --show-current"))},
            new MenuOption{ Id = "2", Title = "Show status", Action = () => writer.WriteGitStatus(gitService.RunGitCommand("status"))},
            new MenuOption{ Id = "0", Title = "Quit", Action = () => Environment.Exit(0) }
            ]);

        foreach (var option in options)
        {
            Console.WriteLine($"{option.Id}. {option.Title}");
        }
        var input = Console.ReadLine();
        if (input != null)
        {
            var selectedOption = options.FirstOrDefault(o => o.Id == input);
            if (selectedOption != null)
            {
                selectedOption.Action();
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }

}
