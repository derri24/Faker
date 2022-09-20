using System;
using System.Collections.Generic;
using System.Reflection;

namespace Faker.Generators
{
    public class ListGenerator : ValueGenerator
    {
        public override object Random(Type type)
        {
            var genericType = type.GenericTypeArguments;
            var list = Activator.CreateInstance(type);

            var size = (byte) ObjRandom.Next(1, 15);
            for (int i = 0; i < size; i++)
            {
                var methodInfo = typeof(Faker).GetMethod("Create");
                var methodInfoRef = methodInfo.MakeGenericMethod(genericType[0]);
                var element = methodInfoRef.Invoke(new Faker(), null);
                var tempArray = new object[] {element};
                MethodInfo magicMethod = type.GetMethod("Add");
                magicMethod.Invoke(list, tempArray);
            }
            return list;
        }
    }
}
