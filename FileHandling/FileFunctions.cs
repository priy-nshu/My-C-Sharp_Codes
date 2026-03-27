using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileFunctions
{
    public string filePath = @"D:\Code\Visual Studio\FileHandling\CFileHandling.cs";

    public void FileStreamFunction()
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            if (stream.CanRead)
            {
                byte[] buffer = new byte[10];// Buffer to hold read bytes or chars
                int byteRead;

                while ((byteRead = stream.Read(buffer, 0, buffer.Length - 2)) > 0)
                {
                    string content = System.Text.Encoding.UTF8.GetString(buffer, 0, byteRead);
                    Console.WriteLine(content);
                }
            }
            else
            {
                Console.WriteLine("The stream does not support reading");
            }//The stream is automatically closed and disposed here because of "using" keyword
            Console.WriteLine("reading using file object");
            foreach (string line in File.ReadLines(filePath))
            {
                Console.WriteLine(line);
            }
        }
    }

    public void StreamReaderFunction()
    {
        //Create object of FileInfofor Specified path
        FileInfo fi = new FileInfo(filePath);

        //Open file for Read\Write
        FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);

        //Create object of StreamReader by passing FileStream object on which it needs to operate on
        StreamReader sr = new StreamReader(fs);

        //Use ReadToEnd to read all
        String fileContent = sr.ReadToEnd();
        Console.WriteLine(fileContent);
    }

    public void fileAccess()
    {
        Console.WriteLine("Please enter a name of the file to renamed");
        string FileName = Console.ReadLine();

        //Check if file exists
        if (File.Exists(FileName))
        {
            Console.WriteLine("Please enter a new name for this file");
            string newFileName = Console.ReadLine();

            //Checking if the string is null or not
            if (FileName != String.Empty)
            {
                //renaming the file
                File.Move(FileName, newFileName);

                //checking if hte file has been renamed or not
                if (File.Exists(newFileName))
                {
                    Console.WriteLine("The file was renamed to " + newFileName);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Unsuccessful");
                }
            }
        }
    }

    public void DirectoryAccess()
    {
        Console.WriteLine("Please Enter a name for the new Directory");

        string dirName = Console.ReadLine();

        if (dirName != string.Empty)
        {
            Directory.CreateDirectory(dirName);
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Directory was Created at d" + Environment.CurrentDirectory);
                Console.ReadKey();
            }
        }

    }

    public void GetFilesFromDirectory()
    {
        Console.WriteLine("Please enter name of existing directory");

        string dirName = Console.ReadLine();

        //Checking if string is empty or not
        if (dirName != string.Empty)
        {
            if (Directory.Exists(dirName))
            {
                string[] FileDirectory = Directory.GetFiles(dirName);

                foreach (string file in FileDirectory)
                {
                   Console.WriteLine(file);
                }
            }
        }
    }
}

