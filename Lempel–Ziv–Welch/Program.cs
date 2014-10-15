using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs;

namespace Lempel_Ziv_Welch
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.PrintToFile = false;

            Logger.output("***** Lempel Ziv Welch Algorithm *****\n");

            string originalText = "thisisthe";
            //string originalText = "AFBABFCABCFDABCDFEABCDEF";
            //string originalText = "AAAAAAAAAAAAAAAAA";
            //string originalText = "ABABCDDDABCDABCD";
            //string originalText = "TOBEORNOTTOBEORTOBEORNOT";

            //string originalText = "A AB ABC ABCD ABCDE ABCDEF ABCDEFG ABCDEFGH ABCDEFGHI ABCDEFGHIJ ABCDEFGHIJK ABCDEFGHIJKL ABCDEFGHIJKLM ABCDEFGHIJKLMN"
            //    + " ABCDEFGHIJKLMNO ABCDEFGHIJKLMNOP ABCDEFGHIJKLMNOPQ ABCDEFGHIJKLMNOPQR ABCDEFGHIJKLMNOPQRS ABCDEFGHIJKLMNOPQRST ABCDEFGHIJKLMNOPQRSTU"
            //        + " ABCDEFGHIJKLMNOPQRSTUV ABCDEFGHIJKLMNOPQRSTUVW ABCDEFGHIJKLMNOPQRSTUVWX ABCDEFGHIJKLMNOPQRSTUVWXY ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //char[] arr = originalText.ToCharArray();
            //Array.Reverse(arr);
            //originalText = new StringBuilder(originalText).Append(arr).ToString();
            //string s = "AZ AY AX AW AV AU AT AS AR AQ AP AO AN AM AL AK AJ AI AH AG AF AE AD AC AB AA ";
            //originalText += s;

            LempelZivWelchAlgorithm compresser = new LempelZivWelchAlgorithm();
            byte bytesPerSymbol;
            string compressedText = compresser.compress(originalText, out bytesPerSymbol, 9);

            //decompress
            string decompressedText = compresser.decompress(compressedText, bytesPerSymbol);

            Console.ReadLine();
        }
    }
}
