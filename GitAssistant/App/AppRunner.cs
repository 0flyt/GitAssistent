using GitAssistant.Git;
using GitAssistant.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitAssistant.App;

public class AppRunner
{

    public void Run()
    {
        Screens.ShowWelcome();
        Screens.ShowCurrentBranch();

    }
}
