using System;
using System.Collections.Generic;
using System.Linq;

    public static class ExtentionMethods
    {
     public static int IntergerExtention(this string str)
    {
        return Int32.Parse(str);
    }

    public static bool IsGreaterThan(this int i, int value) { 
        return i > value;
    }

    public static int GetWordCount(this string str)
    {
        if (!string.IsNullOrEmpty(str))
        {
            string[] strArray = str.Split(' ');
            return strArray.Length; //str.Count()
        }
        return 0;
    }
    public static DateTime NormalStatic()
    {
        return DateTime.Now;
    }
    }
