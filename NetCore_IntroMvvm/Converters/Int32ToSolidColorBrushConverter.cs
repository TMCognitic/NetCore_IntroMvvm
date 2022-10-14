using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace NetCore_IntroMvvm.Converters
{
    public class Int32ToSolidColorBrushConverter : IValueConverter
    {
        //ViewModel To View
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int code)
            {
                if (code >= 0 && code < 10)
                {
                    Color[] colors = new Color[] { Colors.Red, Colors.AliceBlue, Colors.Coral, Colors.Yellow, Colors.Pink, Colors.LightBlue, Colors.Chartreuse, Colors.Purple, Colors.LightGreen, Colors.Black };
                    return new SolidColorBrush(colors[code]);
                }
            }

            return Binding.DoNothing;
        }


        //View To ViewModel
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
