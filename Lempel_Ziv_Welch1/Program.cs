using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using Logs;

namespace Lempel_Ziv_Welch1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.PrintToFile = false;
            Logger.PrintDateToConsole = false;

            Logger.output("*************LempelZivWelchAlgorithm*************");

            //string originalText = "thisisthe";
            //string originalText = "TOBEORNOTTOBEORNOT";
            //string originalText = "AAAAAAAAAAAAAAAAAAAA";
            //string originalText = "AB ABC ABCD ABCDE ABCDEF ABCDEFG ABCDEFGH ABCDEFGHI ABCDEFGHIJ ABCDEFGHIJK "
            //    + "ABCDEFGHIJKL ABCDEFGHIJKLM ABCDEFGHIJKLMN ABCDEFGHIJKLMNO ABCDEFGHIJKLMNOP ABCDEFGHIJKLMNOPQ "
            //        + "ABCDEFGHIJKLMNOPQR ABCDEFGHIJKLMNOPQRS ABCDEFGHIJKLMNOPQRST ABCDEFGHIJKLMNOPQRSTU "
            //                + "ABCDEFGHIJKLMNOPQRSTUV ABCDEFGHIJKLMNOPQRSTUVW ABCDEFGHIJKLMNOPQRSTUVWX "
            //                        + "ABCDEFGHIJKLMNOPQRSTUVWXY ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string originalText = "ABABCABCDABCDEABCDEFABCDEFGABCDEFGHABCDEFGHIABCDEFGHIJABCDEFGHIJK"
                + "ABCDEFGHIJKLABCDEFGHIJKLMABCDEFGHIJKLMNABCDEFGHIJKLMNOABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQ"
                    + "ABCDEFGHIJKLMNOPQRABCDEFGHIJKLMNOPQRSABCDEFGHIJKLMNOPQRSTABCDEFGHIJKLMNOPQRSTU"
                            + "ABCDEFGHIJKLMNOPQRSTUVABCDEFGHIJKLMNOPQRSTUVW ABCDEFGHIJKLMNOPQRSTUVWX"
                                    + "ABCDEFGHIJKLMNOPQRSTUVWXYABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //originalText += "ZZYYXXWWUUTTSSRRQQPPOONNMMLLKKJJIIHHGGFFEEDDCCBBAA  ??";
            //char[] arr = originalText.ToCharArray();
            //Array.Reverse(arr);
            //originalText = new StringBuilder(originalText).Append(arr).ToString();
            originalText += originalText.ToLower();

            Logger.emptyLine();
            Logger.output(string.Format("Original Text: {0}", originalText));
            Logger.emptyLine();

            LempelZivWelchAlgorithm LZW = new LempelZivWelchAlgorithm();
            byte bitsPerSymbol;
            List<BitArray> compressed = LZW.compress(originalText, out bitsPerSymbol, 12);

            Logger.emptyLine();
            Logger.output("Binary Result");
            foreach (BitArray binNum in compressed)
            {
                printBitArray(binNum);
            }
            Logger.emptyLine();

            string decompressed = LZW.decompress(compressed);

            Logger.emptyLine();
            Logger.output(string.Format("Decompressed Text: {0}", decompressed));
            Logger.emptyLine();

            //check for equality
            if (originalText == decompressed)
            {
                Logger.output("original text and decompressed are equals!");
            }
            else
            {
                Logger.output("original text and decompressed are different, wrong algorithm.");
            }

            //Logger.output(string.Format("Number of bits per symbol: {0}", bitsPerSymbol));
            //printBitArray(compressed[0]);

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
