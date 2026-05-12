using GitAssistant.Git;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitAssistant.UI;

public static class Screens
{
    public static void ShowWelcome()
    {
        string logo = @"
 ██████╗ ██╗████████╗ █████╗ ███████╗███████╗
██╔════╝ ██║╚══██╔══╝██╔══██╗██╔════╝██╔════╝
██║  ███╗██║   ██║   ███████║███████╗███████╗ 
██║   ██║██║   ██║   ██╔══██║╚════██║╚════██║
╚██████╔╝██║   ██║   ██║  ██║███████║███████║
 ╚═════╝ ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚══════╝
";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(logo);
        Console.ResetColor();
    }

    public static void ShowCurrentBranch()
    {
        var gitService = new GitService();
        
        var dto = gitService.RunGitCommand("branch --show-current");

        if(dto.Success)
        {
            Console.Write("Branch: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(dto.Message);
        }
        if(!dto.Success)
        {
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine(dto.Message);
        }
        Console.ResetColor();
    }
}
