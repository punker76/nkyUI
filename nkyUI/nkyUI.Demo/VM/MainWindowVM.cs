using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace nkyUI.Demo.VM
{
    internal class MainWindowVM
    {
        public ReactiveCommand<object> DoSomethingCoolCommand { get; }

        public MainWindowVM()
        {
            DoSomethingCoolCommand = ReactiveCommand.Create();
            DoSomethingCoolCommand.Subscribe(_ => DoSomethingCool());
        }

        private void DoSomethingCool()
        {
            //Something cool should happen...
        }
    }
}