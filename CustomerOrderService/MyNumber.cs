using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyNumber
{
    int[] numArr;
    public MyNumber() { }
    public MyNumber(int[] numArr) { this.numArr = numArr; }

    public bool AreAllNumbersEven(int[] numArr)
    {
        int x = 0;
        for (; x < numArr.Count(); x++)
        {
            if (numArr[x] % 2 != 0)
            {
                return false;
            }
        }
        return true;
    }
}
    
