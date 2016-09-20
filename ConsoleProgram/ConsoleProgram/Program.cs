﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProgram.Puzzle;

namespace ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("输入要运行的算法：");
                string algorithm = Console.ReadLine();
                switch (algorithm.ToLower())
                {
                    case "didi":
                        Didi.Run();
                        break;
                    case "didi2":
                        Didi2.Run();
                        break;
                }
            }
        }
    }
}
