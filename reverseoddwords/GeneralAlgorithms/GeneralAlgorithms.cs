using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.algorithms
{
    public static class GeneralAlgorithms
    {
        public static string reverseOddWords(this string input)
        {
            //add a white space at end, so algorithm can work right
            input += " ";

            string output = "";
            int counter = 0;
            string token = "";

            //save previous character
            char prevC = ' ';

            foreach (char c in input)
            {
                if (c == ' ')
                {
                    if (prevC != ' ')
                    {
                        //white space found, reset token

                        //if odd, reverse token
                        if (counter % 2 != 0) //odd index word
                        {
                            token = Reverse(token);
                        }
                        //add token to result 
                        output += token + " ";

                        //reset
                        token = "";
                        //increase counter
                        counter++;
                    }
                }
                else
                {
                    //add character to token
                    token += c;
                }
                prevC = c;
            }

            return output;
        }

        internal static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int findSecondLargest(int[] input)
        {
            //largest number
            int max = input[0];
            //second largest number
            int sec = input[0];
            //aux number

            ////find largest
            //foreach (int i in input)
            //{
            //    max = i > max ? i : max;
            //}
            ////find second largest
            //foreach (int i in input)
            //{
            //    sec = i > sec && i < max ? i : sec;
            //}

            int length = input.Length;
            for (int i = 0, item; i < length; i++)
            {
                item = input[i];
                if (item > max)
                {
                    sec = max;
                    max = item;
                }
                else if (item < max && (item > sec || sec == max))
                {
                    sec = item;
                }
            }

            //foreach (int cur in input)
            //{
            //    if (cur > max)
            //    {
            //        sec = max;
            //        max = cur;
            //    }
            //    else if (cur < max)
            //    {
            //        sec = cur > sec ? cur : sec;
            //    }
            //}

            return sec;
        }
    }
}
