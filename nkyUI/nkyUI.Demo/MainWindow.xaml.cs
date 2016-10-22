using Avalonia.Markup.Xaml;
using nkyUI.Controls;
using nkyUI.Demo.VM;

namespace nkyUI.Demo
{
    public class MainWindow : KYUIWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
            DataContext = new MainWindowVM();
            App.AttachDevTools(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}