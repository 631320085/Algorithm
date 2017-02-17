using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzlesConsole.Puzzles
{
    class Didi
    {
        //矩阵行数、列数，允许消耗体力值
        static int n, m, minp;
        static int[,] map;

        //最少消耗路径
        static string minPath;

        public static void Run()
        {
            n = m = 8;
            minp = 30;
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
            string currentPoint = "(" + cn + "," + cm + ")";
            if (path.Contains(currentPoint) || p > minp)
            {
                //当前点在路径中返回（避免循环路径），消耗体力超过当前最小消耗返回
                return;
            }
            path += currentPoint;
            if (cn == 0 && cm == m - 1)
            {
                //达到终点，如果该路径是最小消耗路径记录下来，更新最小消耗体力，超过此消耗的路径将放弃
                minp = p;
                minPath = path;
            }
            else
            {
                //移动条件：
                //1 行或列坐标变化后仍在矩阵中
                //2 目标坐标不是上一个坐标（避免原路返回）
                //3 目标坐标值为1可移动
                //4 移动后体力消耗不超过最大值

                //各个方向移动时的行或列的坐标变化
                int an1 = cn + 1;
                int an2 = cn - 1;
                int am1 = cm + 1;
                int am2 = cm - 1;
                //向下
                if (an1 < n && (an1 != bn || cm != bm) && map[an1, cm] == 1)
                {
                    Move(path, cn, cm, an1, cm, p);
                }
                //向右
                if (am1 < m && (cn != bn || am1 != bm) && map[cn, am1] == 1)
                {
                    Move(path, cn, cm, cn, am1, p + 1);
                }
                //向上
                if (an2 >= 0 && (an2 != bn || cm != bm) && map[an2, cm] == 1)
                {
                    Move(path, cn, cm, an2, cm, p + 3);
                }
                //向左
                if (am2 >= 0 && (cn != bn || am2 != bm) && map[cn, am2] == 1)
                {
                    Move(path, cn, cm, cn, am2, p + 1);
                }
            }
        }
    }
}
