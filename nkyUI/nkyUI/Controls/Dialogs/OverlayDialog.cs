using Avalonia.Controls;

namespace nkyUI.Controls.Dialogs
{
    public class OverlayDialog
    {
        public Grid DialogContainer { get; internal set; }
        public TextBlock DialogTitleBlock { get; internal set; }
        public TextBlock DialogTextBlock { get; internal set; }
    }
}