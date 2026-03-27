using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  internal class CFileHandling
  {
     public void WriteToTextFile()
    {
        //Creates the File at specified location
        string file = "D:/Code/GreyHeads.txt";
        StreamWriter sw = new StreamWriter(file,true);
        
        //To write on the console Screen
        Console.WriteLine("Enter the Text that you want to write on File");
        
        //To read your input
        string str=Console.ReadLine();
        //to write a line in the buffer
        sw.WriteLine(str);
        //To write the output in the stream else it may stay in the memory
        sw.Flush();


        //Close the stream
        sw.Close();
     }

    public void ReadFromTextFile()
    {
        StreamReader sr = new StreamReader("D:/Code/GreyHeads.txt");

        Console.WriteLine("Contents of the file:");

        //This is use to specify from where 
        //to start reading input stream
        sr.BaseStream.Seek(0, SeekOrigin.Begin);

        string str = sr.ReadLine();

        //To read the whole file line by line
        while (str != null)
        {
            Console.WriteLine(str); 
            str = sr.ReadLine();
        }
        Console.ReadLine();

        sr.Close();
    }
}

