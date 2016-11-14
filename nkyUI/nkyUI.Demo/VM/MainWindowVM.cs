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
        }
    }
}