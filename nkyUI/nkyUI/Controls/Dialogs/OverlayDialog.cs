using Avalonia.Controls;
using Avalonia.Controls.Presenters;

namespace nkyUI.Controls.Dialogs
{
    public class OverlayDialog
    {
        public Grid DialogContainer { get; internal set; }
        public ContentPresenter DialogCustomContents { get; internal set; }
        public TextBlock DialogTitleBlock { get; internal set; }
        public TextBlock DialogTextBlock { get; internal set; }
    }
}