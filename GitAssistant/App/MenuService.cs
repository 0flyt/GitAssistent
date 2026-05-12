using GitAssistant.Git;
using GitAssistant.Models;

namespace GitAssistant.App;

public static class MenuService
{
    public static void ShowOptions()
    {
        var gitService = new GitService();

        var options = new List<MenuOption> ([
            new MenuOption{ Id = "1", Title = "Show current branch", Action = () => gitService.RunGitCommand("branch --show-current")},
            new MenuOption{ Id = "0", Title = "Quit", Action = () => Environment.Exit(0) }
            ]);

        foreach (var option in options)
        {
            Console.WriteLine($"{option.Id}. {option.Title}");
        }
    }
}
