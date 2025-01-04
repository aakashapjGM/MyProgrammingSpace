using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BankApplication;


namespace MyProgramSpace
{

    class Program
    {
        public class Encap
        {
            public int varOne { get; private set; }
            public string? varTwo{private get; set;}

            public void varOneSetter(int Num)
            {
                this.varOne = Num;
                Console.WriteLine($"varOne is set to value {Num}");
            }

            public void varTwoGetter()
            {
                Console.WriteLine($"varTwo value is {this.varTwo}");
            }
        }
        // Main Method
        public static void Main(String[] args)
        {
            BankApplication.Program2 BankApplicationObj = new();
            BankApplicationObj.print();
            Encap enObj = new();
            enObj.varTwo = "Hello Aakash";
            enObj.varOneSetter(20);
            enObj.varTwoGetter();
            Console.WriteLine(enObj.varOne);
        }
    }

}

class ClassName
{



}



