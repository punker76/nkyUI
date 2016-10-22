using System.Threading.Tasks;

namespace nkyUI.Controls.Dialogs
{
    public static class DialogManager
    {
        public static async Task<KYUIDialogResult> ShowMessageAsync(this KYUIWindow window, string title, string text)
        {
            window.ShowOverlay();
            window.DialogHost.DialogTitleBlock.Text = title;
            window.DialogHost.DialogTextBlock.Text = text;
            //window.HideOverlay();
            return KYUIDialogResult.Affirmative;
        }
    }
}