

namespace Encuentas
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Xamarin.Forms;

    public class EquipoFavoritoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            var equipoFav = (string)value;
            var color = Color.Black;
            switch (equipoFav)
            {
                case "Colombia":
                    color = Color.Yellow;
                    break;
                case "México":
                    color = Color.Green;
                    break;
                case "Perú":
                    color = Color.Red;
                    break;
                case "Argentina":
                    color = Color.AliceBlue;
                    break;
                case "Brasil":
                    color = Color.LimeGreen;
                    break;
                case "Alemania":
                    color = Color.DarkRed;
                    break;
                case "España":
                    color = Color.YellowGreen;
                    break;
                default:
                    break;
            }
            return color;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
