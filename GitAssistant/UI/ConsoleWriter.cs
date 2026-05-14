using GitAssistant.Git;

namespace GitAssistant.UI;

public class ConsoleWriter
{
    public void WriteGitStatus(GitRepoResponseDTO dto)
    {
        if (dto.Message.Contains("On branch"))
        {
            var lines = dto.Message.Split("\n");

            foreach (var line in lines)
            {
                if(!line.Contains('('))
                {
                    Console.WriteLine(line);
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

            //Console.ResetColor();
            //Console.WriteLine(String.Concat(parts[2..]).Trim('.'));
        }
        else
        {

        }
    }
}
