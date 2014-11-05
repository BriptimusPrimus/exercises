using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Write a program that:
//• Computes (without printing them) and store on a matrix all the
//coefficients of Pascal’s triangle up to depth n
//• Prints the lines from the stored triangle from line m to n (m and n
//are values taken from command line)

//2. The solution from previous question will use a lot more memory than
//necessary. Indeed only the previous line is needed to compute any given
//line. You will now write a program that will print all Pascal’s triangle
//lines up to depth n using only two arrays.
namespace PascalTriangle
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("******************Pascal's Triangle******************");

            Console.Write("Please provide the desired depth of triangle: ");
            int depth = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int[,] C = ComputePascalTriangle(depth);
            Console.WriteLine("Pascal's triangle coefficients computed");

            Console.WriteLine("Please hit enter to print the triangle");
            Console.ReadLine();
            Console.Write("Please provide the first line from which you desire to print(m): ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Please provide the last line you desire to print(n): ");
            int n = int.Parse(Console.ReadLine());
            PrintPascalTriangle(C, m, n);
            Console.WriteLine();

            Console.WriteLine("Second solution to Pascal's Triangle");
            Console.Write("Please provide the desired depth of triangle: ");
            depth = int.Parse(Console.ReadLine());
            ComputeAndPrint(depth);

            Console.ReadLine();
        }

        static int[,] ComputePascalTriangle(int depth)
        {
            int[,] C = new int[depth + 1, depth + 1];
            
            for (int i = 0; i <= depth; i++)
            {
                for (int p = 0; p <= i; p++)
                {
                    if (p == 0 || p == i)
                        C[i, p] = 1;
                    else
                        C[i, p] = C[i - 1, p - 1] + C[i - 1, p];
                }
            }

            return C;
        }

        static void PrintPascalTriangle(int[,] C, int m, int n)
        {
            for (int i = m; i <= n; i++)
            {
                for (int p = 0; p <= i; p++)
                {
                    Console.Write(" {0}", C[i, p]);    
                }
                Console.WriteLine("\n");
            }
        }

        static void ComputeAndPrint(int depth)
        { 
            int[] A = new int[depth + 1];
            int[] B = new int[depth + 1];

            for (int i = 0; i <= depth; i++)
            {
                for (int p = 0; p <= i; p++)
                {
                    if (p == 0 || p == i)
                        A[p] = 1;
                    else
                        A[p] = B[p - 1] + B[p];
                }
                for (int p = 0; p <= i; p++)
                {
                    B[p] = A[p];
                }
                for (int p = 0; p <= i; p++)
                {
                    Console.Write(" {0}", A[p]);
                }
                Console.WriteLine("\n");                
            }
        }
    }
}
