using Avalonia.Controls;
using Avalonia.Controls.Presenters;

namespace nkyUI.Controls.Dialogs
{
    public class OverlayDialog
    {
        public Grid Container { get; internal set; }
        public ContentPresenter CustomContents { get; internal set; }
        public TextBlock TitleBlock { get; internal set; }
        public TextBlock TextBlock { get; internal set; }
        public Button AffirmativeButton { get; internal set; }
        public Button NegativeButton { get; internal set; }
        public Button AuxiliaryButton1 { get; internal set; }
        public Button AuxiliaryButton2 { get; internal set; }
        public TextBox Input { get; internal set; }
    }
}