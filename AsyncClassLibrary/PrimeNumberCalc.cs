using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncClassLibrary
{
    public class PrimeNumberCalc
    {
        //public int BlahInput { get; set; }

        public long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;

            while (count < n)
            {
                long b = 2;
                int prime = 1;

                while(b * b <= a)
                {
                    if(a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }

                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }

        public async Task<long> FindPrimeNumbersAsync(int n)
        {
            var task = await Task.Run(() => FindPrimeNumber(n));
            return task;
        }

        public static void FindPrimeThread1()
        {
            PrimeNumberCalc calc = new PrimeNumberCalc();
            Console.WriteLine(calc.FindPrimeNumber(250000));
        }

        public static void FindPrimeThread2()
        {
            PrimeNumberCalc calc = new PrimeNumberCalc();
            Console.WriteLine(calc.FindPrimeNumber(400000));
            Console.WriteLine(DateTime.Now);
        }

        //public void FindPrimeThreadTwo()
        //{
        //    int n = BlahInput;
        //    int count = 0;
        //    long a = 2;

        //    while (count < n)
        //    {
        //        long b = 2;
        //        int prime = 1;

        //        while (b * b <= a)
        //        {
        //            if (a % b == 0)
        //            {
        //                prime = 0;
        //                break;
        //            }
        //            b++;
        //        }

        //        if (prime > 0)
        //        {
        //            count++;
        //        }
        //        a++;
        //    }
        //    Console.WriteLine(--a);
        //}
    }
}
