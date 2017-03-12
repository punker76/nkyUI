using Avalonia.Controls;
using Avalonia.Markup;
using Avalonia.Media.Imaging;
using System;
using System.Globalization;

namespace nkyUI.Converters
{

    class IconImageConverter : IValueConverter
    {
        private static IconImageConverter s_converter = new IconImageConverter();

        public static IconImageConverter Converter => s_converter;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WindowIcon)
            {
                var windowIcon = value as WindowIcon;
                return null;
                // return new Bitmap(windowIcon.Save());
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
