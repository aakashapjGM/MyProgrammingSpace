using System;

namespace MyProgramSpace
{
  class MyClassProgram
  {
    static void Main(string[] args)
    {
      int[] myNumArray = new int[4];

      for(int i=0; i<myNumArray.Length; i++)
      {
        myNumArray[i] = i * 20;
      }

      foreach(int j in myNumArray)
      {
        Console.WriteLine($"My Array Value: {j}");
      }
    }
  }
}
