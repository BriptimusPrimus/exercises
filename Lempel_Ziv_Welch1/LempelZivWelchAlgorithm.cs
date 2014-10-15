using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using Logs;

namespace Lempel_Ziv_Welch1
{
    class LempelZivWelchAlgorithm
    {
        private string printFormat = "{0, 20} {1, 8} {2, 20} {3, 20}";

        public List<BitArray> compress(string inputText, out byte bitsPerSymbol, byte maxBits = 8)
        {
            //list with the resulting symbols numeric(integer) values
            List<int> numericOutput = this.LZWCompress(inputText, maxBits);

            Logger.emptyLine();
            Logger.output("Algorithm result: ");
            for (int i = 0; i < numericOutput.Count; i++)
            {
                Logger.output(string.Format("{0}->{1}", i, numericOutput[i]));
            }

            //find out how many bits are used
            int higVal = numericOutput.Max();
            bitsPerSymbol = this.howManyBitsToReachNumber(higVal);
            
            List<BitArray> result = new List<BitArray>();
            foreach (int n in numericOutput)
            {
                result.Add(Dec2Bin(n, bitsPerSymbol));
            }
            return result;
        }


        public string decompress(List<BitArray> input)
        {
            List<int> symbolCodes = new List<int>();
            foreach (BitArray binNum in input)
            {
                symbolCodes.Add(Bin2Dec(binNum));
            }
            Logger.emptyLine();
            Logger.output("numeric symbol codes: ");
            for (int i = 0; i < symbolCodes.Count; i++)
            {
                Logger.output(string.Format("{0}->{1}", i, symbolCodes[i]));
            }

            string result;
            result = this.LZWDeCompress(symbolCodes);
            return result;
        }

        private List<int> LZWCompress(string text, byte maxBits = 8)
        {
            //print algorithm header
            Logger.output(String.Format(printFormat, "Current", "Next", "Output", "Add to Dict"));

            int capacity = (int)Math.Pow(2, maxBits);
            List<int> output = new List<int>();

            //create the basic dictionary
            Dictionary<string, int> dict = this.getAsciiDictionary();

            int val;
            StringBuilder curr = new StringBuilder();
            //main loop
            int i = 0;
            while (i < text.Length)
            {
                string prev = curr.ToString();
                curr.Append(text[i]);
                string strCurr = curr.ToString();

                if (dict.TryGetValue(strCurr, out val))
                {
                    if (prev != string.Empty)
                    {
                        Logger.output(String.Format(printFormat,
                            prev + "=" + dict[prev], text[i] + "=" + dict[text[i].ToString()], "----", "----"));
                    }
                    i++;
                }
                else
                {
                    //add previous symbol to the results
                    output.Add(dict[prev]);

                    //check if dictionary is full
                    if (dict.Count >= capacity)
                    {
                        //no more symbols allowed on the dictionary
                        Logger.output(String.Format(printFormat,
                            prev + "=" + dict[prev], text[i] + "=" + dict[text[i].ToString()],
                            prev + "=" + dict[prev], "--FULL--"));
                    }
                    else
                    {
                        //add new symbol to dictionary
                        dict.Add(strCurr, dict.Count);

                        Logger.output(String.Format(printFormat,
                            prev + "=" + dict[prev], text[i] + "=" + dict[text[i].ToString()],
                            prev + "=" + dict[prev], strCurr + "=" + (dict.Count - 1)));
                    }
                    curr.Clear();
                }
            }

            //after cycle ended, add last token to the output
            string symbol = curr.ToString();
            output.Add(dict[symbol]);
            Logger.output(String.Format(printFormat,
                symbol + "=" + dict[symbol], "----", symbol + "=" + dict[symbol], "----"));

            return output;
        }

        private string LZWDeCompress(List<int> input)
        {
            StringBuilder output = new StringBuilder();

            //create the basic dictionary
            Dictionary<string, int> dict = this.getAsciiDictionary();

            string curr, next;
            //main loop
            int i = 0;
            while (i < input.Count)
            {
                curr = dict.FirstOrDefault(x => x.Value == input[i]).Key;
                if(i + 1 < input.Count)
                {
                    if (dict.ContainsValue(input[i + 1]))
                    {
                        next = dict.FirstOrDefault(x => x.Value == input[i + 1]).Key;
                        dict.Add(curr + next[0], dict.Count);
                    }
                    else
                    {
                        dict.Add(curr + curr[0], dict.Count);
                    }
                }
                output.Append(curr);
                i++;
            }

            return output.ToString();
        }

        //creates and returns a dictionary with all ascii values represented as strings
        private Dictionary<string, int> getAsciiDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            //1 byte = 8 bits = 256 decimal values
            for (int i = Byte.MinValue; i <= Byte.MaxValue; i++)
            {
                char c = (char)i;
                string strSymbol = Convert.ToString(c);
                try
                {
                    dictionary.Add(strSymbol, i);
                }
                catch
                {
                    Logger.output(string.Format("Problems with number {0}, char {1}, symbol {2}", i, c, strSymbol));
                }
            }
            return dictionary;
        }

        private static BitArray Dec2Bin(int dec, int sizeOfBin = 8)
        {
            BitArray bin = new BitArray(sizeOfBin);
            int index = sizeOfBin - 1;
            int bit = 0;
            while (dec >= 1)
            {
                bit = dec % 2;
                dec /= 2;
                bin[index--] = bit > 0;
            }
            return bin;
        }

        private static int Bin2Dec(BitArray bin)
        {
            int dec = 0;
            int count = 1;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                if (bin[i])
                {
                    dec += count;
                }
                count *= 2;
            }
            return dec;
        }

        //callculates the minimum number of bits required to represent a decimal number
        private byte howManyBitsToReachNumber(int number)
        {
            byte bits = 0;
            int values = 1;
            while (true)
            {
                bits++;
                values *= 2;
                if (values > number)
                {
                    return bits;
                }
            }
        }

    }
}
