using System;
using System.Globalization;
using System.Security.Cryptography;

namespace MyProgramSpace
{
  class MyProgramSpace
  {
    public class MySampleClass 
    {

        // Constructor 1: no parameter constructor method, calls the second constructor
        public MySampleClass() : this(10) 
        {
            Console.WriteLine($"Cosntructor Chaining:");
        }

        // Constructor 2: constructor with one parameter
        public MySampleClass(int Age) : this(28, 90398)
        {
            Console.WriteLine($"Construtor 2:{Age}");
            // Second Constructor
        }

        public MySampleClass(int Age, int Num)
        {
            Console.WriteLine($"Construtor 3:{Age} , {Num}");
        }

        

    }

    static void Main(string[] args)
    {
        MySampleClass x = new();
    }
  }
}

