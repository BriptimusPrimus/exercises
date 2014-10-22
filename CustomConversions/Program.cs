﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Conversions *****\n");

            // Make a Rectangle.
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();

            Console.WriteLine();

            // Convert r into a Square,
            // based on the height of the Rectangle.
            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();

            // Converting an int to a Square.
            Square sq2 = (Square)90;
            Console.WriteLine("sq2 = {0}", sq2);

            // Converting a Square to an int.
            int side = (int)sq2;
            Console.WriteLine("Side length of sq2 = {0}", side);

            Square s3 = new Square();
            s3.Length = 83;

            // Attempt to make an implicit cast?
            Rectangle rect2 = s3;

            // Explicit cast syntax still OK!
            Square s4 = new Square();
            s4.Length = 3;
            Rectangle rect3 = (Rectangle)s4;
            Console.WriteLine("rect3 = {0}", rect3);
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
