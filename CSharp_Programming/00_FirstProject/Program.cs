using System;
using System.Diagnostics;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args, Console console)
        {
            string condition = console.ReadLine();

            if (condition == "A"){
                console.WriteLine("Hello Aakash");
            }else if (condition == "B")
                console.WriteLine("Hello Bera");
            
        }
    }
}