using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AsyncClassLibrary;

namespace AsyncConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumberCalc pc = new PrimeNumberCalc();

            //FindPrimesSync(pc);
            //FindPrimesAsync(pc);
            FindPrimesMultithread(pc);

            Console.ReadKey();
        }

        public static void FindPrimesSync(PrimeNumberCalc pc)
        {
            Console.WriteLine(DateTime.Now);
            var a = pc.FindPrimeNumber(250000);
            Console.WriteLine(DateTime.Now);
            var b = pc.FindPrimeNumber(400000);
            Console.WriteLine(DateTime.Now);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(DateTime.Now);
        }

        public static void FindPrimesAsync(PrimeNumberCalc pc)
        {
            Console.WriteLine(DateTime.Now);
            var a = pc.FindPrimeNumbersAsync(250000);
            Console.WriteLine(DateTime.Now);
            var b = pc.FindPrimeNumbersAsync(400000);
            Console.WriteLine(DateTime.Now);

            Console.WriteLine(a.Result);
            Console.WriteLine(b.Result);
            Console.WriteLine(DateTime.Now);
        }

        public static void FindPrimesMultithread(PrimeNumberCalc pc)
        {
            Thread t1 = new Thread(new ThreadStart(PrimeNumberCalc.FindPrimeThread1));
            Thread t2 = new Thread(new ThreadStart(PrimeNumberCalc.FindPrimeThread2));

            ///pc.BlahInput = 40000;
            ///Thread t2 = new Thread(new ThreadStart(pc.FindPrimeThreadTwo));

            Console.WriteLine(DateTime.Now);
            t1.Start();
            Console.WriteLine(DateTime.Now);
            t2.Start();
            Console.WriteLine(DateTime.Now);
        }
    }
}
