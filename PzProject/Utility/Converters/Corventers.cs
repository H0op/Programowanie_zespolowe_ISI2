using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PzProject.Utility.Converters
{
    class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string url = @"https://image.tmdb.org/t/p/w640" + (string)value;
                BitmapImage image = new BitmapImage(new Uri(url));

                return image;
            }
            catch (Exception e)
            {
                return new BitmapImage();
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
