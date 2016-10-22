using Avalonia.Interactivity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace nkyUI.Controls.Dialogs
{
    public static class DialogManager
    {
        public static async Task<KYUIDialogResult> ShowMessageAsync(this KYUIWindow window, string title, string text)
        {
            window.ShowOverlay();
            window.DialogHost.TitleBlock.Text = title;
            window.DialogHost.TextBlock.Text = text;
            KYUIDialogResult result = KYUIDialogResult.Affirmative;
            ManualResetEvent resultReady = new ManualResetEvent(false);
            EventHandler<RoutedEventArgs> affirmativeClickHandler = (s, e) =>
            {
                result = KYUIDialogResult.Affirmative;
                resultReady.Set();
            };
            window.DialogHost.AffirmativeButton.Click += affirmativeClickHandler;
            await (Task.Run(() => resultReady.WaitOne()));
            window.HideOverlay();
            return result;
        }
    }
}