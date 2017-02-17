using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuzzlesConsole.Puzzles;

namespace PuzzlesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose puzzle");
                Console.WriteLine("  1. didi");
                Console.WriteLine("Input puzzle number:");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        Didi.Run();
                        break;
                }
            }
        }
    }
}
