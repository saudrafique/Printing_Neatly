
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

    static void solveWordWrap(int[] l, int n,
                                        int M,string[] s)
    {


        int[,] extras = new int[n + 1, n + 1];

        int[,] linecost = new int[n + 1, n + 1];


        int[] c = new int[n + 1];

        int[] p = new int[n + 1];


        for (int i = 1; i <= n; i++)
        {
            extras[i, i] = M - l[i - 1];

            for (int j = i + 1; j <= n; j++)
                extras[i, j] = extras[i, j - 1]
                                - l[j - 1] - 1;
        }


        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j <= n; j++)
            {
                if (extras[i, j] < 0)
                    linecost[i, j] = MAX;
                else if (j == n &&
                            extras[i, j] >= 0)
                    linecost[i, j] = 0;
                else
                    linecost[i, j] = extras[i, j]
                                * extras[i, j];
            }
        }


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

        string[] str = { "saud", "talha", "likes", "to", "code" };
        int[,] cost = new int[str.Length, str.Length];
        int[] o = new int[str.Length];

        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < str.Length; j++)
            {
                o[j] = str[j].Length;
                Console.Write(o[j] + " ");
            }
        }

        int n = o.Length;
        int M = 12;
        solveWordWrap(o, n, M,str);
    }
}
