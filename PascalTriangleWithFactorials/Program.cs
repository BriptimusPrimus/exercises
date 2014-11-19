using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangleWithFactorials
{
    class Program
    {
        static void Main(string[] args)
        {
		    int i,j=1,k=1,tab,n=4; //i = raws  j = elements
		    long element;
		    for(i=0;i<10;i++) //Raws 0,1,2,3,4,5...
		    {
			    print_space(10-i);
			    for(j=0;j<k;j++) //Raw 0, element 1
			    {
				    element = (facto(i))/(facto(j)*(facto(i-j)));
				    Console.Write(element);
				    Console.Write("   ");
			    }
			    k++;
			    Console.WriteLine("");
			    n-=1;
		    }
            Console.ReadLine();
        }

	    static void print_space (int num_spa)
	    {
		    int sp;
		    for (sp = 0; sp < num_spa; sp ++)
		    {
			    Console.Write("   ");
		    }
	    }

        static private long facto(long num)
	    {
	        long i = num;
	        long fact = 1;
	        for(i=num;i>1;i--)
		    {
			    fact*=i;
		    }
		    return fact;
	    }
    }
}
