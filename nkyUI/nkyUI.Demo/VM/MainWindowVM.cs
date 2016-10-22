using nkyUI.Controls.Dialogs;
using nkyUI.Demo.Helpers;
using ReactiveUI;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace nkyUI.Demo.VM
{
    internal class MainWindowVM : WindowViewModel
    {
        public ReactiveCommand<object> DoSomethingCoolCommand { get; }

        public MainWindowVM()
        {
            DoSomethingCoolCommand = ReactiveCommand.Create();
            DoSomethingCoolCommand.Subscribe(_ => DoSomethingCool().GetAwaiter().GetResult());
        }

        private async Task DoSomethingCool()
        {
            //Something cool should happen...
            await View.Window.ShowMessageAsync("A popup!", "It's not very polished yet");
        }
    }
}