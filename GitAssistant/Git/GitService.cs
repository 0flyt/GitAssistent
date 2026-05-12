using System.Diagnostics;

namespace GitAssistant.Git;

public class GitService
{
    public GitRepoResponseDTO RunGitCommand(string arguments)
    {
        var process = new Process();
        //var dto = new GitRepoResponseDTO();

        //process.StartInfo.WorkingDirectory = "C:\\Users\\bjorn\\source\\repos";

        process.StartInfo.FileName = "git";
        process.StartInfo.Arguments = arguments;

        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        if (string.IsNullOrWhiteSpace(error))
        {
            return new GitRepoResponseDTO()
            {
                Message = output,
                Success = true
            };
        }

        return new GitRepoResponseDTO()
        {
            Message = error,
            Success = false
        };
    }
}
