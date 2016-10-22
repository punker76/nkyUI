using Avalonia.Controls;

namespace nkyUI.Controls.Dialogs
{
    public static class ControlVisibilityHelper
    {
        public static void Bury(this Control control)
        {
            control.Opacity = 0;
            control.ZIndex = -1;
            control.IsEnabled = false;
        }

        public static void Resurface(this Control control)
        {
            control.Opacity = 1;
            control.ZIndex = 1;
            control.IsEnabled = true;
        }
    }
}