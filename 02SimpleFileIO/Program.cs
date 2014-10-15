﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace _02SimpleFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            string[] myTasks = {
              "Fix bathroom sink", "Call Dave",
              "Call Mom and Dad", "Play Xbox 360"};

            // Write out all data to file on C drive.
            File.WriteAllLines(@".\tasks.txt", myTasks);

            // Read it all back and print out.
            foreach (string task in File.ReadAllLines(@".\tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }
            Console.ReadLine();
        }
    }
}
