using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace flows
{//a[i,j] стоимость перехода i->j
    class FlowCapacity
    {

        int[,] Capacity;
        int[,] Flow;                        
        int N;
        bool[] Visited;
        public FlowCapacity(int[,] ab)
        {
            N = ab.GetLength(0);
            Visited = new bool[N];
            Capacity = (int[,])ab.Clone();
            Flow = new int[N, N];
        } 

        public void Solution()
        {
            int a;
            Visited[0] = true;
            while (DFS(0, int.MaxValue, out a));
               // for (int i = 0; i<N; ;
        }

        bool DFS(int i, int flowValue, out int newFlowValue)
        {
            
            newFlowValue = flowValue;
            if (i == N - 1)
                return true;

            int j = 0;
            bool ok = false;

            while (j < N && !ok)
            {
                if (Capacity[i, j] > Flow[i, j] && !Visited[j])
                {
                    newFlowValue = Min(flowValue, Capacity[i, j] - Flow[i, j]);
                    Visited[j] = true;
                    ok = DFS(j, newFlowValue, out newFlowValue);
                    Visited[j] = false;
                }
                j++;
            }

            if (ok)
            {
                j--;
                Flow[i, j] += newFlowValue;
            }
            else
            {
                j = 0;
                while (j < N && !ok)
                {
                    if (0 < Flow[j, i] && !Visited[j])
                    {
                        newFlowValue = Min(flowValue, Flow[j, i]);
                        Visited[j] = true;
                        ok = DFS(j, newFlowValue, out newFlowValue);
                        Visited[j] = false;
                    }
                    j++;
                }

                if (ok)
                {
                    j--;
                    Flow[j, i] -= newFlowValue;
                }
            }
            return ok;
        }

        public void PrintResult()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write("{0, -3} ", Flow[i, j]);

                Console.WriteLine();
            }
        }
    }
}
    