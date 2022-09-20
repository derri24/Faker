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

        private Dictionary<string, ValueGenerator> generators;

        private int countTypes;

        public Faker()
        {
            generators = new Dictionary<string, ValueGenerator>();
            InitDictionary();
        }

        private void InitDictionary()
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

        private void GenerateProperties(Type type, Object obj)
        {
            var properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
                properties[i].SetValue(obj, Create(properties[i].PropertyType));
        }

        private void GenerateFields(Type type, Object obj)
        {
            var fields = type.GetFields();
            for (int i = 0; i < fields.Length; i++)
                fields[i].SetValue(obj, Create(fields[i].FieldType));
        }

        private object GenerateConstructors(Type type)
        {
            var constructors =
                type.GetConstructors(BindingFlags.Instance | BindingFlags.Public)
                    .OrderByDescending(x => x.GetParameters().Length).ToList();
            if (constructors.Count == 0 && type.BaseType != typeof(ValueType))
                throw new Exception("Невозможно создать объект с приватным конструктором.");
            for (int i = 0; i < constructors.Count; i++)
            {
                List<object> parameterValues = new List<object>();
                var parameters = constructors[i].GetParameters();
                for (int j = 0; j < parameters.Length; j++)
                    parameterValues.Add(Create(parameters[j].ParameterType));
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
            if (generators.ContainsKey(type.Name))
            {
                var valueGenerator = generators[type.Name];
                return valueGenerator.Random(type);
            }

            if (type.IsValueType)
                return Activator.CreateInstance(type);

            countTypes++;
            if (countTypes > 25)
            {
                countTypes--;
                return null;
            }

            var obj = GenerateConstructors(type);
            GenerateProperties(type, obj);
            GenerateFields(type, obj);
            countTypes--;
            return obj;
        }
    }
}