using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Faker.Generators;

namespace Faker
{
    public struct Point
    {
        public int x;
        public int y;
        private int ss;
        private int sss;
    }

    public class A
    {
        public B b { get; set; }
        public B b1 { get; set; }
        public B b2 { get; set; }
        public B b3 { get; set; }
        public B b4 { get; set; }
        public B b5 { get; set; }
    }

    public class B
    {
        public C c { get; set; }
    }

    public class C
    {
        public A a { get; set; }
    }

    public class User
    {
        public int b;
        public List<List<int>> l;
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Faker faker = new Faker();
            var a = faker.Create<A>();
            var a6 = faker.Create<uint>();
            User user = faker.Create<User>();
            //   User s = new User(0);
            //ValueGenerator v = new ListGenerator();
            // v.Random(typeof(List<User>));
        }
    }
}