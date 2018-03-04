using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
         static void Main(string[] args)
        {
            var testMain = MainThread("1");
            Console.WriteLine("Cursor Moved");
            var testMain2 = MainThread("2");
            Task.WaitAll(testMain,testMain2);
            Console.WriteLine("All Conditions Completed");
            Console.ReadLine();
        }

        private static async Task<decimal> MainThread(string taskno)
        {
            var task = longCalculation();
            Console.WriteLine("Other Tasks Independently Started");
            var a = await task;
            Console.WriteLine($"Task {taskno} from longCalculation Completed");
            return a;          
        }

        private static async Task<decimal> longCalculation()
        {
            Console.WriteLine("Long Calculation Stated");
            await Task.Delay(3000);
            Console.WriteLine("Long Calculation Ended");
            return 1;            
        }
    }
}
