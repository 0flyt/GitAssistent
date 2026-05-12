using GitAssistant.UI;

namespace GitAssistant.App;

public class AppRunner
{

    public void Run()
    {
        Screens.ShowWelcome();
        MenuService.ShowOptions();
        Screens.ShowCurrentBranch();

    }
}
