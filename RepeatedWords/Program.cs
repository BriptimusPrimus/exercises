using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace RepeatedWords
{

    //Count repeated words in a sentence. 
    //Result should be a list of repeated words with the number of occurrences. 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Count repeated words in a sentence:");
            
            Dictionary<string, int> rep = RepeatedWords
                (" Welcome: to Bahamas!, have a   very, very, very nice day. You: are welcome this day! Very nice");
            foreach (var vp in rep)
            {
                Console.WriteLine("Word {0} is reapeted {1} times", vp.Key, vp.Value);
            }

            Console.ReadLine();
        }

        static Dictionary<string, int> RepeatedWords(string input) 
        {
            input = input.ToLower();
            Dictionary<string, int> words = new Dictionary<string, int>();

            //string[] arr = Regex.Split(input,  @"[^a-zA-Z]+");
            var matches = Regex.Matches(input, "[a-zA-Z]+");

            Console.WriteLine("All words");
            int count = 0;
            foreach(var m in matches)
            {
                string w = m.ToString();                     
                Console.WriteLine("{0}: {1}", count++, w);
                if (words.ContainsKey(w))
                {
                    words[w]++;
                }
                else 
                {
                    words.Add(w, 1);
                }
            }
            Console.WriteLine();

            return words.Where(x => x.Value > 1)
                .ToDictionary(t => t.Key, t => t.Value);           
        }
    }
}
