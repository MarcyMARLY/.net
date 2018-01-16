using System;
using TestApp1.Model;
using System.Collections;

using System.Collections.Generic;
//using TestApp1.Packet;
/**/
namespace TestApp1
{
    enum Color
    {
        Blue,
        Green,
        White
    }

    class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            Console.WriteLine(typeof(Class1));
            int x=6-2;
            Console.WriteLine(x);
            ConstantDeclaration();
            //string[] s = {"dd"};
            string[] s = new string[1];
            s[0] = "ff"; 
            
            Statement(s);
            UsingWhile(s);
            Console.WriteLine(Range(5, 10));
            foreach(int i in Range(7, 10))
            {
                Console.WriteLine(i);
            }

            ChUnCh();

            Pair<int, string> p = new Pair<int, string> { first = 1, second = "dddd" };
            int g = p.first;

            Animal cat1 = new Cat(4, 5, "blue");
            Cat cat = new Cat(10, 34, "green");
            Console.WriteLine(cat.getColor()); // when it's static , it's no access to method; Now it's instance
            Console.WriteLine("x={0}", x); // here 0 means to use the firt elment from the array args
            Fun.SetCounter(4);
            Fun f1 = new Fun();
            Fun f2 = new Fun();
            Console.WriteLine(f1.GetCnt()); //4
            Console.WriteLine(f2.GetCnt());//5
            Console.WriteLine(Fun.GetCounter());//6

            List<string> names = new List<string>();
            names.Add("ddd");
            names.Add("ddds");
            foreach(string ir in names)
            {
                Console.WriteLine(ir);
            }
       

            Console.ReadLine();

        }
        static void ConstantDeclaration()
        {
            int a;
            int b = 4, c = 5;
            a = 10;
            a--;
            Console.WriteLine(a + b + c);
        }

        static void Statement(string [] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine("Line");
            }
        }
        static void UsingWhile(String [] args)
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }
            foreach(string s in args)
            {
                Console.WriteLine(s);
            }
        }
        static IEnumerable<int> Range(int from, int to)
        {
            for(int i = from; i < to; i++)
            {
                yield return i;
            }
        }
        static void ChUnCh()
        {
            int x = int.MaxValue;
            /*unchecked
            {
                Console.WriteLine(x + 1);
            }
            checked
            {
                Console.WriteLine(x + 1);
            }*/
            
        }
        public class Pair<TFirst,TSecond> {
            public TFirst first;
             public TSecond second;

        }

        public class Animal
        {
            private int age;
            private int weight;

            public Animal(int age, int weight)
            {
                this.age = age;
                this.weight = weight;
            }
        }
        public class Cat : Animal {
            private string eyeColor;
            public Cat(int age, int weight, string eyeColor) : base(age, weight){
                this.eyeColor = eyeColor;
            }
            public string getColor()
            {
                return this.eyeColor;
            }
        }
        public class Fun
        {
            private static int counter;
            private int cnt;
            public Fun()
            {
                cnt = counter++;
            }
            public int GetCnt()
            {
                return cnt;
            }
            public static int GetCounter()
            {
                return counter;
            }
            public static void SetCounter(int value)
            {
                counter = value;
            }
        }

       
    }

}
