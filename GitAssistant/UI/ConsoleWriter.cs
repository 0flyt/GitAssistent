using GitAssistant.Git;

namespace GitAssistant.UI;

public class ConsoleWriter
{
    public void WriteGitStatus(GitRepoResponseDTO dto)
    {
        if (dto.Message.Contains("Your branch is up to date with"))
        {
            var parts = dto.Message.Split("'");
            var branchPart = parts[0].Split(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var branchPartSansNewline = branchPart[2].Split("\n");
            Console.WriteLine($"Branch: {branchPartSansNewline[0]}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Up to date with: " );
            Console.ResetColor();
            Console.WriteLine(parts[1]);

            //var rest = dto.Message.Replace(parts[0] + "'" + parts[1] + "'", "").Trim();
            Console.WriteLine(String.Concat(parts[2..]).Trim('.'));
        }

        //Console.WriteLine(dto.Message);
    }
}
