using ArcMoviesUnity.Droid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ArcMoviesUnity.Converters
{
    [Preserve]
    public sealed class ItemVisibilityEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ItemVisibilityEventArgs itemVisibilityEventArgs))
                throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));

            return itemVisibilityEventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
