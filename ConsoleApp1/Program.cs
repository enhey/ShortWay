using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shortWay
{
    class dijstra
    {
        static int[,] graph = new int[6, 6] { { 10000, 10000, 10, 10000, 30, 100 }, { 10000, 10000, 5, 10000, 10000, 10000 }, { 10000, 10000, 10000, 50, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10 }, { 10000, 10000, 10000, 20, 10000, 60 }, { 10000, 10000, 10000, 10000, 10000, 10000 } };
        static int[] S = new int[6] { 0, 0, 0, 0, 0, 0 };//最短路径的顶点集合
        static string[] mid = new string[6] { "", "", "", "", "", "" };//点的路线
        public static int IsContain(int m)//判断元素是否在mst中
        {
            int index = -1;
            for (int i = 1; i < 6; i++)
            {
                if (S[i] == m)
                {
                    index = i;
                }
            }
            return index;
        }
        /// <summary>
        /// Dijkstrah实现最短路算法
        /// </summary>
        static void ShortestPathByDijkstra()
        {
            int min;
            int next;

            for (int f = 5; f > 0; f--)
            {
                //置为初始值

                min = 1000;
                next = 0;//第一行最小的元素所在的列 next点
                //找出第一行最小的列值
                for (int j = 1; j < 6; j++)//循环第0行的列
                {
                    if ((IsContain(j) == -1) && (graph[0, j] < min))//不在S中,找出第一行最小的元素所在的列
                    {
                        min = graph[0, j];
                        next = j;
                    }
                }
                //将下一个点加入S
                S[next] = next;
                //输出最短距离和路径
                if (min == 1000)
                {
                    Console.WriteLine("V0到V{0}的最短路径为：无", next);
                }
                else
                {
                    Console.WriteLine("V0到V{0}的最短路径为：{1},路径为：V0{2}->V{0}", next, min, mid[next]);
                }
                // 重新初始0行所有列值
                for (int j = 1; j < 6; j++)//循环第0行的列
                {
                    if (IsContain(j) == -1)//初始化除包含在S中的
                    {
                        if ((graph[next, j] + min) < graph[0, j])//如果小于原来的值就替换
                        {
                            graph[0, j] = graph[next, j] + min;
                            mid[j] = mid[next] + "->V" + next;//记录过程点
                        }
                    }
                }

            }

        }


        static void Main(string[] args)
        {
            ShortestPathByDijkstra();

        }
    }
}


