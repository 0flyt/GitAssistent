using GitAssistant.App;
using GitAssistant.Git;

var app = new AppRunner();
var gitService = new GitService();

Console.WriteLine(gitService.RunGitCommand("status"));

app.Run();  