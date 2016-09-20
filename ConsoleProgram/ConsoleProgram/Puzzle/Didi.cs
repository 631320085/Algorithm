using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgram.Puzzle
{
    /// <summary>
    /// 滴滴出行秋招题
    /// http://www.cnblogs.com/SHERO-Vae/p/5882357.html
    /// </summary>
    class Didi
    {
        static int n, m, maxp;
        static int[,] map;

        //最少消耗路径
        static int minp;
        static string minPath;

        public static void Run()
        {
            //string[] input = Console.ReadLine().Split(',');
            //n = int.Parse(input[0]);
            //m = int.Parse(input[1]);
            ////体力最大值（不限制会在循环路径中死循环）
            //maxp = int.Parse(input[2]);
            //map = new int[n, m];
            //for (int i = 0; i < n; i++)
            //{
            //    string[] numbers = Console.ReadLine().Split(' ');
            //    for (int j = 0; j < m; j++)
            //    {
            //        map[i, j] = int.Parse(numbers[j]);
            //    }
            //}
            n = m = 8;
            minp = maxp = 30;
            map = new int[8, 8] {
                {1, 0, 1, 0, 1, 0, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1, 1 },
                {1, 0, 1, 1, 1, 0, 1, 1 },
                {1, 1, 1, 0, 1, 1, 0, 1 },
                {1, 1, 0, 0, 0, 1, 1, 1 },
                {0, 1, 0, 1, 1, 0, 1, 0 },
                {1, 1, 1, 0, 1, 1, 1, 1 },
                {1, 0, 1, 1, 1, 0, 1, 1 }
            };
            DateTime startDate = DateTime.Now;
            Move("", 0, 0, 0, 0, 0);
            DateTime endtDate = DateTime.Now;
            Console.WriteLine("最小消耗路径：" + minPath + " 消耗体力:" + minp);
            Console.WriteLine("耗时：" + (endtDate - startDate).Milliseconds + "ms");
        }

        //递归移动，遍历所有可行路径
        public static void Move(string path, int bn, int bm, int cn, int cm, int p)
        {
            if (cn == 0 && cm == m - 1)
            {
                if(p <= minp)
                {
                    minp = p;
                    minPath = path;
                }
            }
            else
            {
                //各个方向移动时的行或列的坐标变化
                int an1 = cn + 1;
                int an2 = cn - 1;
                int am1 = cm + 1;
                int am2 = cm - 1;

                //条件：
                //1 行或列坐标变化后仍在矩阵中
                //2 目标坐标不是上一个坐标（避免原路返回）
                //3 目标坐标值为1可移动
                //4 移动后体力消耗不超过最大值

                //向下
                if (an1 < n && (an1 != bn || cm != bm) && map[an1, cm] == 1 && p <= maxp)
                {
                    Move(path + "(" + cn + "," + cm + ")", cn, cm, an1, cm, p);
                }
                //向右
                if (am1 < m && (cn != bn || am1 != bm) && map[cn, am1] == 1 && p + 1 <= maxp)
                {
                    Move(path + "(" + cn + "," + cm + ")", cn, cm, cn, am1, p + 1);
                }
                //向上
                if (an2 >= 0 && (an2 != bn || cm != bm) && map[an2, cm] == 1 && p + 3 <= maxp)
                {
                    Move(path + "(" + cn + "," + cm + ")", cn, cm, an2, cm, p + 3);
                }
                //向左
                if (am2 >= 0 && (cn != bn || am2 != bm) && map[cn, am2] == 1 && p + 1 <= maxp)
                {
                    Move(path + "(" + cn + "," + cm + ")", cn, cm, cn, am2, p + 1);
                }
            }
        }
    }
}
