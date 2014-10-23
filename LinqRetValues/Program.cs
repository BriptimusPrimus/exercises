using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ Transformations *****\n");
            IEnumerable<string> subset = GetStringSubset();

            foreach (string item in subset)
            {
                Console.WriteLine(item);
            }

            foreach (string item in GetStringSubsetAsArray())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = {"Light Red", "Green",
                "Yellow", "Dark Red", "Red", "Purple"};

            // Note subset is an IEnumerable<string>-compatible object.
            IEnumerable<string> theRedColors = from c in colors
                                               where c.Contains("Red")
                                               select c;

            return theRedColors;
        }

        static string[] GetStringSubsetAsArray()
        {
            string[] colors = {"Light Red", "Green",
                "Yellow", "Dark Red", "Red", "Purple"};

            var theRedColors = from c in colors
                               where c.Contains("Red")
                               select c;

            // Map results into an array.
            return theRedColors.ToArray();
        }

        class LINQBasedFieldsAreClunky
        {
            private static string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            // Can't use implicit typing here! Must know type of subset!
            private IEnumerable<string> subset = from g in currentVideoGames
                                                 where g.Contains(" ")
                                                 orderby g
                                                 select g;

            public void PrintGames()
            {
                foreach (var item in subset)
                {
                    Console.WriteLine(item);
                }
            }
        }

    }
}
