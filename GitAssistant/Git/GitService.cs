using System.Diagnostics;

namespace GitAssistant.Git;

public class GitService
{
    public string RunGitCommand(string arguments)
    {
        var process = new Process();

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

        return string.IsNullOrWhiteSpace(error)
            ? output
            : error;
    }
}
