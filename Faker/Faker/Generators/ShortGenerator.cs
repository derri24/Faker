using System;

namespace Faker.Generators
{
    public class ShortGenerator:ValueGenerator
    {
        public override object Random(Type type)
        {
            return (short) ObjRandom.Next(short.MinValue, short.MinValue);
        }
    }
}