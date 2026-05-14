using GitAssistant.Git;

namespace GitAssistant.UI;

public class ConsoleWriter
{
    public void WriteGitStatus(GitRepoResponseDTO dto)
    {
        if (dto.Message.Contains("On branch"))
        {
            var lines = dto.Message.Split("\n");

            var cleanedMessage = new List<string>();

            var modifiedFiles = new List<string>();

            foreach (var line in lines)
            {
                if(!line.Contains('('))
                {
                    cleanedMessage.Add(line);

                    if (line.Contains("modified"))
                        modifiedFiles.Add(line);
                }
            }

            foreach (var message in cleanedMessage)
            {
                if (message.Contains("On branch"))
                {
                    Console.Write("Branch: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message.Split(" ")[2]);
                    Console.ResetColor();
                }
                else if (message.Contains("Your branch is up to date with"))
                {
                    Console.Write("Up to date with: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message.Split("'")[1] + "\n");
                    Console.ResetColor();
                }    
                else if (message.Contains("Changes not staged for commit:"))
                {
                    Console.WriteLine("Not staged files:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var modified in modifiedFiles)
                    {
                        Console.WriteLine(modified);
                    }
                    Console.ResetColor();
                }
            }

            //var parts = dto.Message.Split("'");
            //var branchPart = parts[0].Split(" ");
            //var branchPartSansNewline = branchPart[2].Split("\n");
            //Console.Write($"Branch: ");
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(branchPartSansNewline[0]);
            //Console.ResetColor();
            //Console.Write("Up to date with: " );
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine(parts[1]);

            Console.ResetColor();
            //Console.WriteLine(String.Concat(parts[2..]).Trim('.'));
        }
        else
        {

        }
    }
}
