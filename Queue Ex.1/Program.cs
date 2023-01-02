using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_Ex._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sequence N -> N + 1 | N * 2 //// Find the first index of given number P

            var q = new Queue<int>();
            int N = 3;
            int P = 16;

            q.Enqueue(N);

            int index = 0;

            while (true)
            {
                var currentNumber = q.Dequeue();

                if (currentNumber == P)
                {
                    Console.WriteLine($"Current number with index {index} is {P}");
                    break;
                }

                q.Enqueue(currentNumber + 1);
                q.Enqueue(currentNumber * 2);
                index++;
            }
        }
    }
}
