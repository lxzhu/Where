using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereClause
{
    public class Convert
	{
        public static readonly Dictionary<Type, IConverter> Converters;
			
        static Convert()
        {
            Converters = new Dictionary<Type, IConverter>();
            RegisterConverter(typeof(AnyType), (input) => input);
            RegisterConverter(typeof(string), (input) => input);
            RegisterConverter(typeof(char), (input) => input?.FirstOrDefault());

            RegisterConverter(typeof(Int16),
                (input) => { return string.IsNullOrWhiteSpace(input) ? null : (object)Int16.Parse(input); });

            RegisterConverter(typeof(Int32),
                (input) => { return string.IsNullOrWhiteSpace(input) ? null : (object)Int32.Parse(input); });

            RegisterConverter(typeof(Int64),
                (input) => { return string.IsNullOrWhiteSpace(input) ? null : (object)Int64.Parse(input); });

            RegisterConverter(typeof(bool),
                (input) => { return string.IsNullOrWhiteSpace(input) ? null : (object)bool.Parse(input); });

            RegisterConverter(typeof(Guid),
                (input) => { return string.IsNullOrWhiteSpace(input) ? null : (object)Guid.Parse(input); });

            RegisterConverter(typeof(float),
                (input) => { return string.IsNullOrWhiteSpace(input) ? null : (object)float.Parse(input); });

            RegisterConverter(typeof(double),
                (input) => { return string.IsNullOrWhiteSpace(input) ? null : (object)double.Parse(input); });

            RegisterConverter(typeof(DateTime),
                (input) => { return string.IsNullOrWhiteSpace(input) ? null : (object)DateTime.Parse(input); });
        }

        public static void RegisterConverter<T>(Func<string, T> converter)
        {
            Converters[typeof(T)] = new FuncConverter((input)=>converter(input));
        }

        public static void RegisterConverter(Type type, Func<string, object> converter)
        {
			Converters[type] = new FuncConverter(converter);
        }

		public static object ConvertText(string input, Type type)
        {
            if (!Converters.ContainsKey(type))
            {
                throw new Exception($"Converter from string to {type.Name} is not registered.");
            }
            var converter = Converters[type];
            return converter.Convert(input);
        }
	}
}

