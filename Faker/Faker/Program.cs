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
    }
    public class User
    {
        public List<User> _list;

        public string fileName { get; set; }

        public List<List<Point>> lj;
        private List<List<int>> test1;
        private List<Point> test2;
        private int test3;
        
        public User(List<List<int>> yeyeyeyeyey,List<Point> points,int a)
        {
            test1 = yeyeyeyeyey;
            test2 = points;
            test3 = a;
        }
        //private int fileSize;

        // public int Age { get; set; }  
        // public string Name { get; set; }
        // public byte weight;
        // public char favoriteChar;
        // public char favoriChar;
        // public DateTime DateTime;
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Faker faker = new Faker();
            var a = faker.Create<List<List<User>>>();
            // var a = faker.Create<int>();
           // User user = faker.Create<User>();
         //   User s = new User(0);
         //ValueGenerator v = new ListGenerator();
        // v.Random(typeof(List<User>));
        }
    }
}