using System;

namespace Faker.Generators
{
    public class DoubleGenerator:ValueGenerator
    {
        public override object Random(Type type)
        {
            return ObjRandom.NextDouble();
        }
    }
}