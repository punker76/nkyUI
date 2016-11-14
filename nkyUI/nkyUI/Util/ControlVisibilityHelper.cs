using Avalonia.Controls;

namespace nkyUI.Util
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