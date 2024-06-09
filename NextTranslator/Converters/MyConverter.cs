using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NextTranslator.Converters;

public class MyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Console.WriteLine($"Type: {value.GetType()}, Value: {(value as KeyValuePair<string, string>?)}");
        return (value as KeyValuePair<string, string>?).Value.Key;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException("Not supported");
    }
}
