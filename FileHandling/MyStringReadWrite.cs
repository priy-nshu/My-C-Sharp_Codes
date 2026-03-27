using System;
using System.Text;

 internal class MyReaderAndWriter
{
    public void MyStringReader()
    {
        string text = @"You are reading this StringWriter and StringReader in C# article at
                        dotnettutorials.net";
        using (StringReader sr = new StringReader(text))
        {
            int count = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                count++;
                Console.WriteLine("Line {0}: {1}",count,line);
            }
        }
    }

    public void MyStringWriter() {
        string text = "Hello. This is First Line\nHello.This is the Second Line\nHello. This is the Third Line";

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);

        sw.WriteLine(text);
        sw.Flush();
        sw.Close();

        StringReader sr = new StringReader(sb.ToString());

        while(sr.Peek()>-1)
            Console.WriteLine(sr.ReadLine());
    }
}
