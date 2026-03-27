using System;

internal class SimpleArray
{
    int[] a;// new int[100];
    int i, n, sum = 0;

    public void AcceptandPrint()
    {
        Console.Write("Input the numbers of elements to be stored in the array: ");
        n = Convert.ToInt32(Console.ReadLine());
        a = new int[n];

        Console.Write("Input the elements for the array\n");
        for (i = 0; i < n; i++)
        {
            Console.Write("element {0}: ", i);
            a[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (i = 0; i < n; i++)
        {
            sum += a[i];
        }
        Console.WriteLine("Sum is = " + sum);
    }

    public void TwoDArray()
    {
        int[,] a, b, c;
        int row, col;
        Console.Write("Enter the row size ");
        row = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Column size");
        col = Convert.ToInt32(Console.ReadLine());

        a = new int[row, col];
        b = new int[row, col];

        Console.WriteLine("Enter the values for the first array");
        for (i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write("Element [{0}][{1}]: ", i, j);
                a[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        Console.WriteLine("Enter the values for the second array");
        for (i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write("Element [{0}][{1}]: ", i, j);
                b[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        c = new int[row, col];
        for (i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                c[i, j] = a[i, j] + b[i, j];
            }
        }

        for (i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(c[i, j] + " ");
            }
            Console.WriteLine();
        }
    }


}

