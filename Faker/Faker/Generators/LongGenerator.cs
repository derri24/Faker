using System;

namespace Faker.Generators
{
    public class LongGenerator:ValueGenerator
    {
        public override object Random(Type type)
        {
            return ObjRandom.Next(Int32.MinValue, Int32.MaxValue) *
                   ObjRandom.Next(Int32.MinValue, Int32.MaxValue);
        }
    }
}