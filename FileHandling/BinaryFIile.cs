using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BinaryFile
{
    public void BinWriterFunction()
    {
        FileStream fs = File.Open("D:\\MyBinaryFile.bin", FileMode.Create);
        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            bw.Write("0x80234400");
            bw.Write("Windows Explorer Has Stopped Working");
            bw.Write(true);
        }
        Console.WriteLine("Binary file Created!");
    }

    public void BinReaderFunction()
    {
        FileStream fs = File.Open("D:\\MyBinaryFile.bin",FileMode.Open);
        using(BinaryReader br = new BinaryReader(fs))
        {
            Console.WriteLine("Error Code : "+ br.ReadString());
            Console.WriteLine("Message : "+br.ReadString());
            Console.WriteLine("Restart Explorer : "+br.ReadBoolean());
        }
    }
}
