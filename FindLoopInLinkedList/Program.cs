using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLoopInLinkedList
{
    //If you have a single linked list, how would do you find out if there is a loop in the list?
    //What is the operational complexity and memory allocation of your solution?
    //How would it be made better?
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Loop In Linked List");

            int count;
            bool loop;
            Node head; 

            //linked list with loop
            count = 0;
            head = new Node() { Value = count++ } ;
            head.Next = new Node
                {
                    Value = count++,
                    Next = new Node
                        {
                            Value = count++,
                            Next = new Node
                                {
                                    Value = count++,
                                    Next = new Node
                                    {
                                        Value = count++,
                                        Next = new Node
                                        {
                                            Value = count++,
                                            Next = head
                                        }                            
                                    }
                                }
                        }
                };
            //send head of the list to determine if list has a loop
            loop = FindLoop(head);
            Console.WriteLine("List has loop: {0}", loop);
            Console.WriteLine();

            //linked list with no loop
            count = 0;
            head = new Node() { Value = count++ };
            head.Next = new Node
            {
                Value = count++,
                Next = new Node
                {
                    Value = count++,
                    Next = new Node
                    {
                        Value = count++,
                        Next = new Node
                        {
                            Value = count++,
                            Next = new Node
                            {
                                Value = count++,
                                Next = null
                            }
                        }
                    }
                }
            };
            //send head of the list to determine if list has a loop
            loop = FindLoop(head);
            Console.WriteLine("List has loop: {0}", loop);

            Console.ReadLine();
        }

        static bool FindLoop(Node n)
        {
            //no head, no loop
            if (n == null)
            {
                return false;
            }

            //Use two pointers to traverse the list
            //one will go twice as fast as the other one
            Node slow = n;  
            Node fast = n.Next;
            Console.WriteLine("slow points to: {0}", slow == null ? "NULL" : slow.Value.ToString());
            Console.WriteLine("fast points to: {0}", fast == null ? "NULL" : fast.Value.ToString());

            while (fast != null)
            {
                //if both point to the same node
                //we found the loop
                if (slow == fast)
                {                   
                    return true;
                }

                //slow goes to the next node
                slow = slow.Next;
                Console.WriteLine("slow points to: {0}", slow == null ? "NULL" : slow.Value.ToString());

                //fast goes two nodes next
                if (fast.Next == null)
                {
                    //found the end, no loop
                    return false;
                }
                fast = fast.Next.Next;
                Console.WriteLine("fast points to: {0}", fast == null ? "NULL" : fast.Value.ToString());
            }

            //if reached here, there is no loop
            return false;
        }
    }

    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

}
