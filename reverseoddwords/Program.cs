using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using training.algorithms;

namespace training
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Reverse Odd Words";
            Console.WriteLine("**********Reverse Odd Words***********");

            ConsoleColor origBackgroundColor = Console.BackgroundColor;
            ConsoleColor origForegroundColor = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();
            Console.WriteLine("Enter input text: ");

            string inputText = Console.ReadLine();

            string result = inputText.reverseOddWords();

            Console.WriteLine("Output Text: ");
            Console.WriteLine(result);

            Console.BackgroundColor = origBackgroundColor;
            Console.ForegroundColor = origForegroundColor;
            Console.WriteLine();
            Console.WriteLine("Bye bye");

            Console.ReadLine();
        }

        

    }
}
