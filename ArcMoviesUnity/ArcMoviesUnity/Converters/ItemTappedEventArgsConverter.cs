using ArcMoviesUnity.Droid;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ArcMoviesUnity.Converters
{
    [Preserve]
    public sealed class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ItemTappedEventArgs itemTappedEventArgs))
                throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));
                
            return itemTappedEventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
