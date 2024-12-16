using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace MyProgramSpace
{

    class Program
    {

        class printName
        {
            string _Myname;
            int _weight;

             public void setValue(string name, int weight = 60)
             {
                _Myname = name;
                _weight = weight;
             }

             public void getValue()
             {
                Console.WriteLine(nameof(_Myname));
                Console.WriteLine(nameof(_weight));
             }
        }

        

        // Main Method
        public static void Main(String[] args)
        {
            printName MyPrintName = new();

            MyPrintName.setValue("Aakash");
            MyPrintName.getValue();
        }
    }

}

class ClassName
{

    

}



