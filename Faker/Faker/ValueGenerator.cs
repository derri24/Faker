using System;
using System.Runtime.InteropServices;

namespace Faker.Generators
{
    public abstract  class ValueGenerator
    {
        protected static Random ObjRandom { get; set; }

        static ValueGenerator()
        {
            ObjRandom = new Random();
        }
        public abstract object Random(Type type);
    }
}