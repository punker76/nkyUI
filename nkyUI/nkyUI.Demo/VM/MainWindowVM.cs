using nkyUI.Controls.Dialogs;
using nkyUI.Demo.Helpers;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace nkyUI.Demo.VM
{
    internal class MainWindowVM : WindowViewModel
    {
        public ReactiveCommand<Unit> DoSomethingCoolCommand { get; }

        public MainWindowVM()
        {
            DoSomethingCoolCommand = ReactiveCommand.CreateAsyncTask(_ => DoSomethingCool());
        }

        private async Task DoSomethingCool()
        {
            //Something cool should happen...
            var result = await View.Window.ShowMessageAsync("A popup!", "It's not very polished yet. Do you want to continue?", KYUIDialogStyle.AffirmativeAndNegative);
            if (result == KYUIDialogResult.Affirmative)
            {
                await View.Window.ShowMessageAsync("Great!", "Glad to hear it!");
            }
        }
    }
}