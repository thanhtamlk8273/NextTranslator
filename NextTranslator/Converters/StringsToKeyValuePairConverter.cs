using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media.Immutable;

namespace NextTranslator.Converters
{
    internal class StringsToKeyValuePairConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if(values.Count != 2 && !targetType.IsAssignableFrom(typeof(KeyValuePair<string, string>)))
            {
                throw new NotSupportedException();
            }

            if (!values.All(x => x is string or UnsetValueType or null))
            {
                throw new NotSupportedException();
            }

            if (values[0] is not string key || values[1] is not string value)
            {
                return BindingOperations.DoNothing;
            }

            return new KeyValuePair<string, string>(key, value);
        }
    }
}
