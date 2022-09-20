using System;
using System.Globalization;

namespace Faker.Generators
{
    public class DateTimeGenerator:ValueGenerator
    {
        public override object Random(Type type)
        {
            var day = ObjRandom.Next(0,32);
            var month = ObjRandom.Next(0, 13);
            var year = ObjRandom.Next(100, 2100);
            
            var second=ObjRandom.Next(-1, 61);
            var minute=ObjRandom.Next(-1, 61);
            var hour=ObjRandom.Next(-1, 25);
         
            return new DateTime(year,month,day,hour,minute,second);
        }
    }
}