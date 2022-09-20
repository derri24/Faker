using System;

namespace Faker.Generators
{
    public class IntGenerator:ValueGenerator
    {
        public override object Random(Type type)
        {
            return ObjRandom.Next(Int32.MinValue, Int32.MaxValue);
        }
    }
}