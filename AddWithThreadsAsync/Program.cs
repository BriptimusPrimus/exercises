﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace AddWithThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            AddAsync();
            Console.ReadLine();
        }

        private static async Task AddAsync()
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
              Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(10, 10);
            await Sum(ap);

            Console.WriteLine("Other thread is done!");
        }

        static async Task Sum(object data)
        {
            await Task.Run(() =>
            {
                if (data is AddParams)
                {
                    Console.WriteLine("ID of thread in Add(): {0}",
                      Thread.CurrentThread.ManagedThreadId);

                    AddParams ap = (AddParams)data;
                    Console.WriteLine("{0} + {1} is {2}",
                      ap.a, ap.b, ap.a + ap.b);
                }
            });
        }
    }

    class AddParams
    {
        public int a, b;

        public AddParams(int numb1, int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }

}
