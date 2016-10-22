using Avalonia.Interactivity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace nkyUI.Controls.Dialogs
{
    public static class DialogManager
    {
        public static async Task<KYUIDialogResult> ShowMessageAsync(this KYUIWindow window, string title, string text, KYUIDialogStyle dialogStyle = KYUIDialogStyle.Affirmative)
        {
            window.ShowOverlay();
            window.DialogHost.TitleBlock.Text = title;
            window.DialogHost.TextBlock.Text = text;

            switch (dialogStyle)
            {
                case KYUIDialogStyle.AffirmativeAndNegative:
                    window.DialogHost.NegativeButton.Resurface();
                    break;
            }

            KYUIDialogResult result = KYUIDialogResult.Affirmative;

            //Set up waiting
            ManualResetEvent resultReady = new ManualResetEvent(false);
            EventHandler<RoutedEventArgs> affirmativeClickHandler = (s, e) =>
            {
                result = KYUIDialogResult.Affirmative;
                resultReady.Set();
            };
            EventHandler<RoutedEventArgs> negativeClickHandler = (s, e) =>
            {
                result = KYUIDialogResult.Negative;
                resultReady.Set();
            };

            //Register events
            window.DialogHost.AffirmativeButton.Click += affirmativeClickHandler;
            window.DialogHost.NegativeButton.Click += negativeClickHandler;

            //Wait for response
            await (Task.Run(() => resultReady.WaitOne()));

            //Unregister events
            window.DialogHost.AffirmativeButton.Click -= affirmativeClickHandler;
            window.DialogHost.NegativeButton.Click -= negativeClickHandler;

            //Clean up dialog
            window.DialogHost.TitleBlock.Text = string.Empty;
            window.DialogHost.TextBlock.Text = string.Empty;
            window.DialogHost.AffirmativeButton.Content = "OK";
            window.DialogHost.NegativeButton.Content = "Cancel";
            window.DialogHost.NegativeButton.Bury();
            window.DialogHost.AuxiliaryButton1.Bury();
            window.DialogHost.AuxiliaryButton2.Bury();
            window.HideOverlay();

            return result;
        }

        public static async Task<string> ShowInputAsync(this KYUIWindow window, string title, string text, KYUIDialogStyle dialogStyle = KYUIDialogStyle.Affirmative)
        {
            window.ShowOverlay();
            window.DialogHost.TitleBlock.Text = title;
            window.DialogHost.TextBlock.Text = text;
            window.DialogHost.Input.Resurface();

            switch (dialogStyle)
            {
                case KYUIDialogStyle.AffirmativeAndNegative:
                    window.DialogHost.NegativeButton.Resurface();
                    break;
            }

            string result = null;

            //Set up waiting
            ManualResetEvent resultReady = new ManualResetEvent(false);
            EventHandler<RoutedEventArgs> affirmativeClickHandler = (s, e) =>
            {
                result = window.DialogHost.Input.Text;
                resultReady.Set();
            };
            EventHandler<RoutedEventArgs> negativeClickHandler = (s, e) =>
            {
                result = null;
                resultReady.Set();
            };

            //Register events
            window.DialogHost.AffirmativeButton.Click += affirmativeClickHandler;
            window.DialogHost.NegativeButton.Click += negativeClickHandler;

            //Wait for response
            await (Task.Run(() => resultReady.WaitOne()));

            //Unregister events
            window.DialogHost.AffirmativeButton.Click -= affirmativeClickHandler;
            window.DialogHost.NegativeButton.Click -= negativeClickHandler;

            //Clean up dialog
            window.DialogHost.TitleBlock.Text = string.Empty;
            window.DialogHost.TextBlock.Text = string.Empty;
            window.DialogHost.AffirmativeButton.Content = "OK";
            window.DialogHost.NegativeButton.Content = "Cancel";
            window.DialogHost.Input.Text = string.Empty;
            window.DialogHost.Input.Bury();
            window.DialogHost.NegativeButton.Bury();
            window.DialogHost.AuxiliaryButton1.Bury();
            window.DialogHost.AuxiliaryButton2.Bury();
            window.HideOverlay();

            return result;
        }
    }
}