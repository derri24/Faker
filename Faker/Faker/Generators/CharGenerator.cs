using System;

namespace Faker.Generators
{
    public class CharGenerator:ValueGenerator
    {
        public override object Random(Type type)
        {
            return (char) ObjRandom.Next(-1, 256);
        }
    }
}