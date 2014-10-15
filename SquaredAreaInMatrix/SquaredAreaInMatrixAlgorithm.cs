using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaredAreaInMatrix
{
    public class RectangleAreaInMatrixAlgorithm
    {

        public static int BiggestAreaInMatrix(int[,] matrix)
        {
            int max = 0;
            int areaFromNode = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    areaFromNode = CheckAreaFromNode(matrix, i, j);
                    max = areaFromNode > max ? areaFromNode : max;
                }
            }
            return max;
        }

        private static int CheckAreaFromNode(int[,] matrix, int i, int j)
        {
            if (matrix[i, j] != 1)
            {
                return 0;
            }

            int inij = j;
            int newarea = 0;
            int maxarea = 0;
            int height = 0;
            int width = matrix.GetLength(0) - j;
            int prevwidth = 0;

            while (i < matrix.GetLength(0))
            {
                prevwidth = width;
                width = 0;
                height++;
                j = inij;
                while (j < matrix.GetLength(1) && matrix[i, j] == 1 && width < prevwidth)
                {
                    width++;
                    j++;
                }
                if (width < 1)
                {
                    break;
                }
                newarea = width * height;
                maxarea = newarea > maxarea ? newarea : maxarea;
                i++;
            }
            return maxarea;
        }

    }
}
