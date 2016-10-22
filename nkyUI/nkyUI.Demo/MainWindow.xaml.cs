using Avalonia.Markup.Xaml;
using nkyUI.Controls;
using nkyUI.Demo.Helpers;
using nkyUI.Demo.VM;

namespace nkyUI.Demo
{
    public class MainWindow : KYUIWindow, IWindowView
    {
        public MainWindow()
        {
            this.InitializeComponent();
            DataContext = new MainWindowVM();
            App.AttachDevTools(this);
            (DataContext as WindowViewModel).View = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public KYUIWindow Window => this;
    }
}