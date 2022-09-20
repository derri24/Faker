using System;

namespace Faker.Generators
{
    public class BoolGenerator:ValueGenerator
    {
        public override object Random(Type type)
        {
            if (ObjRandom.Next(-1, 2) == 1)
                return true;
            return false;
        }
    }
}