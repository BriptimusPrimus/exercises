using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMissingNumberInArray
{

    //If you have an array with numbers from 1 to n, but 1 number is missing, how do you find the missing number?
    //  What is the operational complexity and memory allocation for your solution?
    //  How could it be made better?
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Missing Number in Array \n");

            int[] arr = { 2, 4, 1, 7, 3, 8, 6 };

            int missing = FindMissingNumber(arr);

            Console.WriteLine("Array numbers: ");
            foreach (int number in arr)
            {
                Console.Write(" {0} ", number);
            }
            Console.WriteLine();

            Console.WriteLine("Missing Number: {0}", missing);

            Console.ReadLine();
        }

        static int FindMissingNumber(int[] arr)
        {
            //get greater number in array
            int n = arr.Length + 1;

            //formula for expected sum of all numbers
            int totalSum = (n * (1 + n)) / 2;
            
            //add all numbers in the array
            int arrSum = 0;
            foreach (int number in arr)
            {
                arrSum += number;
            }

            //return difference between expected and actual sum
            return totalSum - arrSum;
        }
    }
}
