using Avalonia;
using nkyUI.Demo.Helpers;
using nkyUI.Themes;
using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace nkyUI.Demo.VM
{
    internal class MainWindowVM : WindowViewModel
    {
        public ReactiveCommand<object> DoSomethingCoolCommand { get; }
        private bool darkTheme = true;

        public MainWindowVM()
        {
            DoSomethingCoolCommand = ReactiveCommand.Create();
            DoSomethingCoolCommand.Subscribe(_ => DoSomethingCool());
        }

        private void DoSomethingCool()
        {
            //Something cool should happen...

            if (darkTheme)
            {
                ThemeManager.SetTheme(KYUITheme.BaseLight, Application.Current);
            }
            else
            {
                ThemeManager.SetTheme(KYUITheme.BaseDark, Application.Current);
            }
            darkTheme = !darkTheme;
        }
    }
}