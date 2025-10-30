using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'knightlOnAChessboard' function below.
     *
     * The function is expected to return a 2D_INTEGER_ARRAY.
     * The function accepts INTEGER n as parameter.
     */

    public static List<List<int>> knightlOnAChessboard(int n)
    {
        List<List<int>> result = new List<List<int>>();
        
        for (int a = 1; a < n; a++)
        {
        List<int> row = new List<int>();
        for (int b = 1; b < n; b++)
        {
            row.Add(BFS(n, a, b));
        }
        result.Add(row);
    }
    
    return result;
}

private static int BFS(int n, int a, int b)
{
    int[,] moves = {
        {a, b}, {a, -b}, {-a, b}, {-a, -b},
        {b, a}, {b, -a}, {-b, a}, {-b, -a}
    };
    
    bool[,] visited = new bool[n, n];
    Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
    
    queue.Enqueue((0, 0, 0));
    visited[0, 0] = true;
    
    while (queue.Count > 0)
    {
        var (x, y, steps) = queue.Dequeue();
        
        
        if (x == n - 1 && y == n - 1)
        {
            return steps;
        }
    
        for (int i = 0; i < 8; i++)
        {
            int newX = x + moves[i, 0];
            int newY = y + moves[i, 1];
            
            if (newX >= 0 && newX < n && newY >= 0 && newY < n && !visited[newX, newY])
            {
                visited[newX, newY] = true;
                queue.Enqueue((newX, newY, steps + 1));
            }
        }
    }
    
    return -1;
}

    }

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> result = Result.knightlOnAChessboard(n);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}
