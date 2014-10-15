using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSBoxesStack
{
    public class Box
    {
        public int boxId;
        public int height;
        public int weight;

        public Box(int id)
        {
            this.boxId = id;
        }

        public Box(int id, int height, int weight)
        {
            this.boxId = id;
            this.height = height;
            this.weight = weight;
        }

        public static bool operator ==(Box b1, Box b2)
        {
            return b1.boxId == b2.boxId;
        }

        public static bool operator !=(Box b1, Box b2)
        {
            return b1.boxId != b2.boxId;
        }
    }
}
