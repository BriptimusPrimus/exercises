using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs;

namespace Lempel_Ziv_Welch
{
    class LempelZivWelchAlgorithm
    {
        private string printFormat = "{0, 20} {1, 8} {2, 20} {3, 20}";

        public string compress(string inputText, out byte bitsPerSymbol, byte maxBits = 8)
        {
            Logger.emptyLine();
            Logger.output(string.Format("Original Text: {0}", inputText));
            Logger.emptyLine();

            //list with the resulting symbols numeric(integer) values
            List<short> numericOutput = this.LZWCompress(inputText, maxBits);

            Logger.emptyLine();
            Logger.output("Algorithm result: ");
            foreach (short n in numericOutput)
            {
                Logger.output("->" + n);
            }

            //find out how many bits are used
            short higVal = numericOutput.Max();
            bitsPerSymbol = this.howManyBitsToReachNumber(higVal);

            string binaryString = this.convertDecArray2ToBinaryString(numericOutput.ToArray(), bitsPerSymbol);
            //in order to later chop the string into groups of 8 bits (byte) we may need to add some zeroes to the right
            int rest = (8 - binaryString.Length % 8);
            binaryString += new string('0', rest);

            Logger.emptyLine();
            Logger.output(string.Format("Binary String: {0}", binaryString));

            //chop the string in sets of 8 bits and convert them into integer values
            short[] numericResult = this.convertBinaryString2decArray(binaryString, 8);

            Logger.emptyLine();
            Logger.output("Reconvert binary string to byte values: ");
            foreach(short n in numericResult)
            {
                Logger.output("->" + n);
            }

            //we are sure every value is between 0 and 255, so we can cast safely
            string result = this.integers2AsciiChars(numericResult.Select(x => (byte)x).ToArray());

            Logger.emptyLine();
            Logger.output(result);

            return result;
        }

        private List<short> LZWCompress(string text, byte maxBits = 8)
        {
            //print algorithm header
            Logger.output(String.Format(printFormat, "Current", "Next", "Output", "Add to Dict"));

            int capacity = (int)Math.Pow(2, maxBits);
            List<short> output = new List<short>();

            //create the basic dictionary
            Dictionary<string, short> dict = this.getAsciiDictionary();

            short val;
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
                        dict.Add(strCurr, (short)dict.Count);

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

        //creates and returns a dictionary with all ascii values represented as strings
        private Dictionary<string, short> getAsciiDictionary()
        {
            Dictionary<string, short> dictionary = new Dictionary<string, short>();
            //1 byte = 8 bits = 256 decimal values
            for (short i = Byte.MinValue; i <= Byte.MaxValue; i++)
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

        //ask if a collection is full acording to a number of bits
        private bool isSetFull(System.Collections.ICollection set, byte bits)
        {
            int maxItems = (int)Math.Pow(2, bits);
            if (set.Count < maxItems)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            return bits;
        }

        //converts an array of integer decimal numbers to 
        //to its binary string representation
        private string convertDecArray2ToBinaryString(short[] input, byte numBits)
        { 
            StringBuilder strBin = new StringBuilder();
            foreach (short d in input)
            {
                strBin.Append(this.decimalToBinary(d, numBits));
            }
            return strBin.ToString();
        }

        //converts a large binary string into an array of integer decimal numbers        
        private short[] convertBinaryString2decArray(string input, byte numBits)
        {
            List<short> result = new List<short>();
            for (int i = 0; i < input.Length; i += numBits)
            {
                if (input.Length >= i + numBits)
                {
                    string strByte = input.Substring(i, numBits);
                    short dec = this.binaryToDecimal(strByte);
                    result.Add(dec);
                }
            }
            return result.ToArray();
        }

        //converts an integer decimal number to its binary string representation
        //using a given number of bits
        private string decimalToBinary(short dec, byte numBits)
        {
            string bin = Convert.ToString(dec, 2);
            return bin.PadLeft(numBits, '0');
        }

        //converts the binary string representation of a number to its 
        //integer decimal equivalent
        private short binaryToDecimal(string bin)
        {
            short dec = Convert.ToInt16(bin, 2);
            return dec;
        }

        //converts an array of bytes to an string of ascii chars
        private string integers2AsciiChars(byte[] numbers)
        {
            char[] chars = new char[numbers.Length];
            numbers.CopyTo(chars, 0);
            return new string(chars);
        }

        //converts an array of ascii chars to an array of bytes 
        private byte[] asciiChars2Integers(char[] chars)
        {
            byte[] numbers = new byte[chars.Length];
            //chars.CopyTo(numbers, 0);
            for (int i = 0; i < chars.Length; i++)
            {
                numbers[i] = (byte)chars[i];
            }
            return numbers;
        }

        public string decompress(string inputText, byte bitsPerSymbol)
        {
            //transoform the text to bytes
            byte[] compressedBytes = this.asciiChars2Integers(inputText.ToCharArray());

            Logger.emptyLine();
            Logger.output("Input Bytes: ");
            foreach (byte n in compressedBytes)
            {
                Logger.output("->" + n);
            }

            //obtain the binary string of those bytes
            string binaryString =
                this.convertDecArray2ToBinaryString(compressedBytes.Select(x => (short)x).ToArray(), 8);

            Logger.emptyLine();
            Logger.output(string.Format("Binary String: {0}", binaryString));
            
            //chop the string in sets of N-bitsPerSymbol bits and convert those binary sets to decimal
            //this will be the input for the decompresion algorithm
            short[] numericInput = this.convertBinaryString2decArray(binaryString, bitsPerSymbol);

            Logger.emptyLine();
            Logger.output("Numeric input for algorithm: ");
            foreach (short n in numericInput)
            {
                Logger.output("->" + n);
            }

            string result = this.LZWDeCompress(numericInput); 

            Logger.emptyLine();
            Logger.output(string.Format("Decompressed Text: {0}", result));

            return result;
        }

        private string LZWDeCompress(short[] input)
        {
            //print algorithm header
            Logger.output(String.Format(printFormat, "Current", "Next", "Output", "Add to Dict"));

            StringBuilder output = new StringBuilder();

            //create the basic dictionary
            Dictionary<string, short> dict = this.getAsciiDictionary();

            short val;
            StringBuilder curr = new StringBuilder();
            //main loop
            int i = 0;
            while (i < input.Length)
            {
                string prev = curr.ToString();
                string symbol = dict.FirstOrDefault(x => x.Value == input[i]).Key;
                curr.Append(symbol);
                string strCurr = curr.ToString();

                if (dict.TryGetValue(strCurr, out val))
                {
                    i++;
                }
                else
                {
                    //add previous symbol to the results
                    output.Append(prev);

                    //add new symbol to dictionary
                    dict.Add(strCurr, (short)dict.Count);

                    curr.Clear();
                }
            }

            //after cycle ended, add last token to the output
            output.Append(curr.ToString());

            return output.ToString();
        }

    }
}
