using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace k
{
    class VisibilityConvector : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(bool))
            {
                bool count;
                bool success = bool.TryParse(value.ToString(), out count);
                if (!success)
                {
                    return Visibility.Collapsed;
                }

                if (count == false)
                    return Visibility.Collapsed;

                if (count == true)
                    return Visibility.Visible;
            }
            else
            {
                if (value != null)
                    return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
