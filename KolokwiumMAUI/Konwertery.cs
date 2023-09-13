using System.Globalization;

namespace KolokwiumMAUI.Konwertery

{
    internal class DoubleNaIntKonwerter : IValueConverter
    {
        public object Convert(object wartosc, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (wartosc is double wartoscDouble)
            {
                return (int)wartoscDouble;
            }
            return 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    internal class WartoscNaKolorKonwerter : IValueConverter
    {
        public object Convert(object wartosc, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (wartosc is double wartoscDouble)
            {
                return wartoscDouble < 128 ? Color.FromRgb(255, 0, 0) : Color.FromRgb(0, 0, 128);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

