using System;

namespace MyProgramSpace
{
  class MyClassProgram
  {
    static void Main(string[] args)
    {

      DateTime StartDate = new DateTime(2024, 9, 14);

      var EndDate = StartDate.AddDays(10);

      Console.WriteLine(StartDate.Year);
      Console.WriteLine(EndDate.Day);

      


    }
  }
}
