using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace flows
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = File.ReadAllLines(@"C:\Users\IskusnikXD\Source\Repos\flows\flows\info.txt");
            int n = int.Parse(s[0]);
            int[,] ab = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                string[] arr = Regex.Split(s[i + 1], ",| ");
                for (int j = 0; j < arr.Length; j++)
                    ab[i, j] = int.Parse(arr[j]); 
            }
            //Вывод результата
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0, -3} ", ab[i, j]);

                Console.WriteLine();
            }
            FlowCapacity flowCapacity = new FlowCapacity(ab);
            
            Console.WriteLine();
            Console.WriteLine();

            flowCapacity.Solution();
            flowCapacity.PrintResult();
        }
    }
}
