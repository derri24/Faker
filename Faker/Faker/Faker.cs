using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Faker.Generators;

namespace Faker
{
    public class Faker
    {
        public T Create<T>()
        {
            return (T) Create(typeof(T));
        }

        public static void InitDictionary(Dictionary<string, ValueGenerator> generators)
        {
            generators.Add(typeof(bool).Name, new BoolGenerator());
            generators.Add(typeof(byte).Name, new ByteGenerator());
            generators.Add(typeof(char).Name, new CharGenerator());
            generators.Add(typeof(DateTime).Name, new DateTimeGenerator());
            generators.Add(typeof(double).Name, new DoubleGenerator());
            generators.Add(typeof(float).Name, new FloatGenerator());
            generators.Add(typeof(int).Name, new IntGenerator());
            generators.Add(typeof(List<>).Name, new ListGenerator());
            generators.Add(typeof(long).Name, new LongGenerator());
            generators.Add(typeof(short).Name, new ShortGenerator());
            generators.Add(typeof(string).Name, new StringGenerator());
        }

        private static object GetDefaultValue(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }

        public void GenerateProperties(Type type, Object obj, Dictionary<string, ValueGenerator> generators)
        {
            var properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = type.GetProperty(properties[i].Name);
                if (property != null)
                    property.SetValue(obj, Create(property.PropertyType));
            }
        }

        public void GenerateFields(Type type, Object obj, Dictionary<string, ValueGenerator> generators)
        {
            var fields = type.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = type.GetField(fields[i].Name);
                if (field != null)
                    field.SetValue(obj, Create(field.FieldType));
            }
            //брать из тайпа все
        }

        public object GenerateConstructors(Type type, Dictionary<string, ValueGenerator> generators)
        {
            var constructors =
                type.GetConstructors(BindingFlags.Instance | BindingFlags.Public)
                    .OrderByDescending(x => x.GetParameters().Length).ToList();
            if (constructors.Count == 0 && type.BaseType != typeof(ValueType))
                throw new Exception("Невозможно создать объект с приватным конструктором.");
            for (int j = 0; j < constructors.Count; j++)
            {
                List<object> parameterValues = new List<object>();
                var parameters = constructors[j].GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                    parameterValues.Add(Create(parameters[i].ParameterType));
                try
                {
                    var obj = Activator.CreateInstance(type, args: parameterValues.ToArray());
                    return obj;
                }
                catch
                {
                }
            }

            return Activator.CreateInstance(type);
        }

        private object Create(Type type)
        {
            Dictionary<string, ValueGenerator> generators = new Dictionary<string, ValueGenerator>();
            InitDictionary(generators);

            if (generators.ContainsKey(type.Name))
            {
                var valueGenerator = generators[type.Name];
                return valueGenerator.Random(type);
            }

            var obj = GenerateConstructors(type, generators);
            GenerateProperties(type, obj, generators);
            GenerateFields(type, obj, generators);
            return obj;
        }
    }
}