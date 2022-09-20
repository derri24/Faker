using System;

namespace Faker.Generators
{
    public class StringGenerator:ValueGenerator
    {
        public override object Random(Type type)
        {
            string str = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            string result = "";
            for (byte i = 0; i < ObjRandom.Next(0, 255); i++)
                result += str[ObjRandom.Next(0, str.Length)];
            return result;
        }

    }
    
}