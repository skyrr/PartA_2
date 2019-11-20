using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Part_A
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelLoopResult result = Parallel.For(1, 1000, Sum);

            if (!result.IsCompleted)
            {
                Console.WriteLine($"Loop execution interrupted on: {result.LowestBreakIteration}");
            }

            Console.Read();
        }
        private static void Sum(int x, ParallelLoopState parallelLoopState)
        {
            var result = 1;
            for (var i = 1; i <= x; i++)
            {
                result += i;
                if (i == 500)
                    parallelLoopState.Break();
            }
            Console.WriteLine($"Task:  {Task.CurrentId}");
            Console.WriteLine($"Sum {x} equals {result}");
        }
    }
}
