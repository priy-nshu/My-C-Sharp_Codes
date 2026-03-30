using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    internal class JaggedArray
{
    int[] a=new int[100];
    int i, n, sum = 0;
     public void AcceptandPrint()
    {
        int[,] a, b, c;
        int m, n;
        int[][] arr1;
        Console.Write("Input the size of Outer Array: ");
        n=Convert.ToInt32(Console.ReadLine());
        arr1 = new int[n][]; 

        //Display the elements
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter size of {i} inner array: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter Elements for {i} array: ");
            arr1[i] = new int[n];
            for (int j = 0; j < arr1[i].Length; j++) arr1[i][j] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }
        //Display the array elements
        for (int i = 0; i < arr1.Length; i++)
        {
            Console.Write("Element [" + i + "] Array:");
            for (int j = 0; j < arr1[i].Length; j++)
                Console.Write(arr1[i][j] + " ");
            Console.WriteLine();
        }

    }
}