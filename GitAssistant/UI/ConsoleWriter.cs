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

            var stagedFiles = new List<string>();

            var notStagedFiles = new List<string>();

            var gitService = new GitService();
            var shortMessage = gitService.RunGitCommand("status --short").Message.Split("\n");
            foreach (var message in shortMessage)
            {
                if (message.Length == 0)
                    continue;

                if (message[0] == 'M')
                    stagedFiles.Add(message.Substring(3));

                if (message[1] == 'M')
                    notStagedFiles.Add(message.Substring(3));

            }

            foreach (var line in lines)
            {
                if(!line.Contains('('))
                {
                    cleanedMessage.Add(line);
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
                //TODO: Add behid and ahead remote branch.
                else if (message.Contains("Changes not staged for commit:"))
                {
                    Console.WriteLine("Not staged file(s):");
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var modified in notStagedFiles)
                    {
                        Console.WriteLine(modified);
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else if (message.Contains("Changes to be committed:"))
                {
                    Console.WriteLine("To be committed:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var modified in stagedFiles)
                    {
                        Console.WriteLine(modified);
                    }
                    Console.WriteLine();
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
