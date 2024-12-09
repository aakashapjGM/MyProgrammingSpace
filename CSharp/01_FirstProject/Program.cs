using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace MyProgramSpace
{

    class Program
    {
        class nameSet
        {
            string name;

            public void NameFunction(string name)
            {
                
                this.name = name;

                public string get()
                {
                    return this.name;
                }
            }

            
        }
            
                // Main Method
                public static void Main(String[] args)
                {
                    nameSet x = new();
                    x.NameFunction("Aakash");
                    Console.WriteLine(x.get());
                }
    }
}



