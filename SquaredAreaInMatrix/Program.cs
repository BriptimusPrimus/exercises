using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaredAreaInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat0 = new int[3, 4] 
            { 
                { 1, 1, 0, 1 }, 
                { 0, 1, 1, 1 }, 
                { 0, 1, 1, 0 } 
            };
            EvalMatrix(mat0);

            int[,] mat1 = new int[5, 6] 
            { 
                { 1, 1, 1, 1, 1, 1 }, 
                { 1, 1, 1, 1, 1, 0 }, 
                { 1, 1, 1, 1, 0, 0 },
                { 1, 1, 1, 0, 0, 0 }, 
                { 1, 1, 0, 0, 0, 0 } 
            };
            EvalMatrix(mat1);

            int[,] mat2 = new int[6, 6] 
            { 
                { 0, 1, 0, 1, 1, 1 }, 
                { 0, 1, 1, 1, 1, 0 }, 
                { 1, 1, 1, 0, 1, 0 },
                { 0, 1, 1, 1, 1, 0 }, 
                { 0, 1, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };
            EvalMatrix(mat2);

            int[,] mat3 = new int[5, 6] 
            { 
                { 0, 0, 0, 1, 1, 1 }, 
                { 0, 0, 1, 1, 1, 0 }, 
                { 0, 1, 1, 1, 0, 0 },
                { 1, 1, 1, 0, 0, 0 }, 
                { 1, 1, 0, 0, 0, 0 } 
            };
            EvalMatrix(mat3);

            int[,] mat4 = new int[6, 6] 
            { 
                { 0, 0, 0, 0, 0, 1 }, 
                { 0, 0, 0, 0, 1, 1 }, 
                { 0, 0, 0, 1, 1, 1 },
                { 0, 0, 1, 1, 1, 1 }, 
                { 0, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1 }
            };
            EvalMatrix(mat4);

            Console.ReadLine();
        }

        public static void EvalMatrix(int[,] matrix)
        {
            Console.WriteLine("\r\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" {0}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\r\n");

            int max = RectangleAreaInMatrixAlgorithm.BiggestAreaInMatrix(matrix);
            Console.WriteLine("Maximum area of rectangle in the matrix containing all 1s {0}", max);
        }

    }
}
