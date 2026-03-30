using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyFileInfo
{
    public void FileInfoProps()
    {
        string filePath = @"D:\Code\Visual Studio\FileHandling\\Program.cs";
        FileInfo fileInfo = new FileInfo(filePath);
        if (fileInfo.Exists)
        {
            Console.WriteLine($"Directory: {fileInfo.Directory}");
            Console.WriteLine($"Directory Name: {fileInfo.DirectoryName}");
            Console.WriteLine($"Length in bytes: {fileInfo.Length}");
            Console.WriteLine($"Name: {fileInfo.Name}");
            Console.WriteLine($"Is read only: {fileInfo.IsReadOnly}");
            Console.WriteLine($"File Exists: {fileInfo.Exists}");
        }
    }
}
