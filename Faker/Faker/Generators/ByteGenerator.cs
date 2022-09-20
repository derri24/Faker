using System;

namespace Faker.Generators
{
    public class ByteGenerator : ValueGenerator
    {
        public override object Random(Type type)
        {
            return (byte) ObjRandom.Next(-1, 256);
        }
    }
}