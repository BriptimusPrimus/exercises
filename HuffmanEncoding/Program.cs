using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Logs;
using System.Collections;

namespace HuffmanEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.PrintToFile = false;
            Logger.PrintDateToConsole = false;

            Logger.output("*************Huffman Encoding Algorithm*************");

            string originalText = "MISSISSIPPIRIVER_";
            //string originalText = "HELLO WORLD";
            
            HuffmanAlgorithm compressor = new HuffmanAlgorithm();
            var bits = compressor.HuffmanCompress(originalText);

            Logger.emptyLine();
            Logger.output("Final Result:");
            printBitArray(bits);

            Console.ReadLine();
        }

        private static void printBitArray(BitArray binary)
        {
            StringBuilder binString = new StringBuilder();
            foreach (bool bit in binary)
            {
                binString.Append(bit ? '1' : '0');
            }
            Logger.output(binString.ToString());
        }
    }
}
