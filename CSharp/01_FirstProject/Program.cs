using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace MyProgramSpace
{

    class Program
    {

        class myClass
        {
            public const int Value = 10;
            public myClass(int Num)
            {
                Console.WriteLine(Value + Num);
            }
        }

        // Main Method
        public static void Main(String[] args)
        {
            myClass test = new(10); // O/p - 20
            Console.WriteLine(myClass.Value); // O/p - 10
        }
    }

}

class ClassName
{



}



