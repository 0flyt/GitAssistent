using GitAssistant.UI;

namespace GitAssistant.App;

public class AppRunner
{

    public void Run()
    {
        Screens.ShowWelcome();
        Screens.ShowCurrentBranch();

        while (true)
        {
           MenuService.ShowAndSelectOptions();
        }



            


    }
}
