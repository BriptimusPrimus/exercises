using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSBoxesStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************LCS Boxes Stack Algorithm*************");

            int k = 0;
            List<Box> boxes;
                
            boxes = new List<Box>();
            boxes.AddRange(
                new Box[] 
                {
                    new Box(k++, 10, 1),
                    new Box(k++, 9, 2), 
                    new Box(k++, 8, 3),
                    new Box(k++, 7, 4),
                    new Box(k++, 6, 5),

                    new Box(k++, 5, 6),
                    new Box(k++, 4, 7),
                    new Box(k++, 3, 8),
                    new Box(k++, 2, 9),
                    new Box(k++, 1, 10)
                }
            );
            Stack<Box> tower0 = StackBoxesLCS.StackBoxes(boxes);
            Console.WriteLine("*********Tower 0*********");
            PrintTower(tower0);
            Console.WriteLine();

            boxes = new List<Box>();
            boxes.AddRange(
                new Box[] 
                {
                    new Box(k++, 10, 10),
                    new Box(k++, 9, 9), 
                    new Box(k++, 8, 3),
                    new Box(k++, 7, 4),
                    new Box(k++, 6, 5),

                    new Box(k++, 5, 6),
                    new Box(k++, 4, 4),
                    new Box(k++, 3, 3),
                    new Box(k++, 2, 9),
                    new Box(k++, 1, 10)
                }
            );
            Stack<Box> tower1 = StackBoxesLCS.StackBoxes(boxes);
            Console.WriteLine("*********Tower 1*********");
            PrintTower(tower1);
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void PrintTower(Stack<Box> tower)
        {
            while (tower.Count > 0)
            {
                Box box = tower.Pop();
                Console.WriteLine("Box number: {0}, height: {1}, weight: {2}", 
                    box.boxId, box.height, box.weight);
            }
        }

    }
}
