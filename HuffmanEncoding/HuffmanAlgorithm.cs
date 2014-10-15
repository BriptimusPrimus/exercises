using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using Logs;

namespace HuffmanEncoding
{
    class HuffmanAlgorithm
    {

        public BitArray HuffmanCompress(string input)
        { 
            //create the dictionary
            Dictionary<string, int> dict = this.generateDictionary(input);
                
            //sort items in dictionary
            List<HuffmanNode> list = this.getSortedList(dict);

            //create the binary tree
            HuffmanNode root = this.createTree(list);

            //traverse the tree and get the encoded bitarray
            List<string> codes = new List<string>();
            this.traverseHuffmanTree(root, codes, "");
            Logger.output("Binary codes are: ");
            foreach (string s in codes)
            {
                Logger.output(string.Format("->{0}", s));
            }

            //traverse the tree and get the encoded bitarray
            Dictionary<string, string> codesDict = new Dictionary<string, string>();
            this.traverseHuffmanTree(root, codesDict, "");
            Logger.emptyLine();
            Logger.output("Binary codes are: ");
            foreach (KeyValuePair<string, string> kvp in codesDict)
            {
                Logger.output(string.Format("{0}->{1}", kvp.Key, kvp.Value));
            }

            //convert string list into bit array
            return this.binString2bits(codes);
        }

        //creates a dictionary with the chars and its frecuency on a given string
        private Dictionary<string, int> generateDictionary(string input)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = input.Length - 1; i >= 0 ; i--)
            {
                string c = input[i].ToString();
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            return dict;
        }

        //generates a sorted list of Huffman Nodes from a dictionary of 
        //chars and frecuencies
        private List<HuffmanNode> getSortedList(Dictionary<string, int> dict)
        {
            var nodesList = dict.Select(kvp => new HuffmanNode(kvp.Key, kvp.Value))
                .OrderBy(n => n.Weight).ToList();

            //Create sorted list of chars
            Logger.output("Create sorted list of chars");
            foreach (HuffmanNode n in nodesList)
            {
                Logger.output(string.Format("char: {0}, weight: {1}", n.Symbol, n.Weight));
            }
            Logger.emptyLine();

            return nodesList;
        }

        //Creates the Huffman Binary Tree from a sorted (by weight) 
        //list of nodes
        private HuffmanNode createTree(List<HuffmanNode> list)
        {
            HuffmanNode node1 = null, node2 = null;
            while (list.Count > 1)
            {
                node1 = list[0];
                node2 = list[1];
                list.RemoveRange(0, 2);
                list.Add(
                new HuffmanNode(node2.Symbol + node1.Symbol, node1.Weight + node2.Weight)
                {
                    Left = node2,
                    Right = node1
                });
                list.Sort(new SortHufNodeByWeight());
            }

            return list.First();
        }

        private void traverseHuffmanTree(HuffmanNode node, List<string> codes, string binCode)
        {
            //if node is leaf, add binary string to the list of codes
            if (node.Left == null && node.Right == null)
            {
                codes.Add(binCode);
                return;
            }
            traverseHuffmanTree(node.Left, codes, binCode + "0");
            traverseHuffmanTree(node.Right, codes, binCode + "1");
        }

        private void traverseHuffmanTree(HuffmanNode node, Dictionary<string, string> codes, string binCode)
        {
            //if node is leaf, add binary string to the list of codes
            if (node.Left == null && node.Right == null)
            {
                codes.Add(node.Symbol, binCode);
                return;
            }
            traverseHuffmanTree(node.Left, codes, binCode + "0");
            traverseHuffmanTree(node.Right, codes, binCode + "1");
        }

        private BitArray binString2bits(List<string> codes)
        {
            //calculate total number of bits of all codes
            int length = 0;
            foreach (string s in codes)
            { 
                length += s.Length; 
            }

            BitArray bits = new BitArray(length);
            int count = 0;
            foreach (string binstr in codes)
            {
                foreach (char c in binstr)
                { 
                    bits[count++] = c == '1';
                }
            }

            return bits;
        }

    }

    class SortHufNodeByWeight : IComparer<HuffmanNode>
    {
        public int Compare(HuffmanNode nodeX, HuffmanNode nodeY)
        {
            if (nodeX.Weight > nodeY.Weight)
                return 1;
            if (nodeX.Weight < nodeY.Weight)
                return -1;
            else
                return 0;
        }
    }

}
