using System;

namespace Faker.Generators
{
    public class FloatGenerator : ValueGenerator
    {
        public override object Random(Type type)
        {
            return (float) ObjRandom.NextDouble();
        }
    }
}