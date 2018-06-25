
using System;

public class GFG
{

    static int MAX = int.MaxValue;


    static int printSolution(int[] p, int n,string[] s)
    {
        int k;
        
        if (p[n] == 1)
            k = 1;
        else
            k = printSolution(p, p[n] - 1,s) + 1;

        Console.WriteLine("Line number" + " "
                + k + ": From word no." + " "
                + p[n] + " " + "to" + " " + n);
        return k;
    }

    static void PrintingNeatly(int[] l, int n,
                                        int M,string[] s)
    {

        //extras 2d array will hold value for the number of empty spaces of words from i to j are put in a single line.
        int[,] extras = new int[n + 1, n + 1];
       //linecost will have cost of a line which has words from i to j
        int[,] linecost = new int[n + 1, n + 1];

        //c will have total cost of optimal arrangement of words
        int[] c = new int[n + 1];
        //p is for printing the solution
        int[] p = new int[n + 1];


        for (int i = 1; i <= n; i++)
        {
            extras[i, i] = M - l[i - 1];

            for (int j = i + 1; j <= n; j++)
                extras[i, j] = extras[i, j - 1]
                                - l[j - 1]-1;

        }
        Console.WriteLine("\n----------------------------------------------------------");
        Console.Write("\nBelow matrix show the of the cost of empty spaces left after the words placed in a line \n");
      
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                Console.Write(extras[i, j] + "\t");

            }
            Console.Write("\n");
        }
        Console.WriteLine("\n----------------------------------------------------------");
        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j <= n; j++)
            {
                if (extras[i,j] < 0)
                    linecost[i,j] = MAX;
                else if (j == n && extras[i,j] == 0)
                    linecost[i,j] = 0;
                else
                    linecost[i,j] = extras[i,j] * extras[i,j] * extras[i,j];
            }
        }

        Console.Write("\n");
        Console.WriteLine("\n----------------------------------------------------------");
        Console.Write("\nBelow matrix show the square of the cost of empty spaces left after the words placed in a line:\n");
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                Console.Write(linecost[i, j] + "\t");
            
            }
            Console.Write("\n");
        }
        Console.WriteLine("\n----------------------------------------------------------");

        c[0] = 0;
        for (int j = 1; j <= n; j++)
        {
            c[j] = MAX;
            for (int i = 1; i <= j; i++)
            {
                if (c[i - 1] != MAX && linecost[i, j]
                    != MAX && (c[i - 1] + linecost[i, j]
                                    < c[j]))
                {
                    c[j] = c[i - 1] + linecost[i, j];
                    p[j] = i;
                }
            }
        }

        printSolution(p, n,s);
    }


    public static void Main()
    {
        //str is the passed string needs to be justified.
        string[] str = { "aaa", "bb", "cc", "dddd" };
        
        int[,] cost = new int[str.Length, str.Length];
        int[] strlength = new int[str.Length];
        //Calculating the length of each word in the array
        Console.WriteLine("This is the passed string:");
            for (int j = 0; j < str.Length; j++)
            {
               
                Console.Write(str[j] + " ");

            }
        Console.WriteLine("\n----------------------------------------------------------");
        Console.WriteLine("This is the length of string:");
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < str.Length; j++)
            {
                strlength[j] = str[j].Length;
                Console.Write(strlength[j] + " ");

            }
            
        }
        Console.WriteLine("\n----------------------------------------------------------");
        int Maxlimit = 6;
        PrintingNeatly(strlength, strlength.Length, Maxlimit,str);
    }
}
