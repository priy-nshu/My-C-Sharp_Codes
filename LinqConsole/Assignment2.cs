using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Assignment2
{
    public Stack<Book> sBook = new Stack<Book>();
    public Queue<Student1> qStd = new Queue<Student1>();
    public IList<BooksIssued> lBook = new List<BooksIssued>();

    public void InitializeBooks()
    {
        sBook.Push(new Book { BookId = 001, BookName = "C# basics" });
        sBook.Push(new Book { BookId = 002, BookName = "Visual basics" });
        sBook.Push(new Book { BookId = 003, BookName = "Dot Net" });
    }

    public void InitializeStd()
    {
        qStd.Enqueue(new Student1 { StudentId = 111, StudentName = "Ram" });
        qStd.Enqueue(new Student1 { StudentId = 121, StudentName = "Shyam" });    }

    public void IssuedBook()
    {
        while (sBook.Count > 0 && qStd.Count > 0)
        {
            Book book = sBook.Pop();
            Student1 std = qStd.Dequeue();

            lBook.Add(new BooksIssued
            {
                Bk = book,
                Std = std,
                DtIssued = DateTime.Now
            });
        }
    }

    public void displayIBooks()
    {
        foreach (var issue in lBook)
        {
            Console.WriteLine($"{issue.Std.StudentName} issued {issue.Bk.BookName} on {issue.DtIssued}");
        }
    }

    public void displayRBooks()
    {
        foreach(var book in sBook)
        {
            Console.WriteLine($"Remaining: {book.BookId} - {book.BookName}");
        }
    }
    
    public void Run()
    {
        InitializeBooks();
        InitializeStd();

        IssuedBook();

        displayIBooks();
        displayRBooks();
    }
}

    public class BooksIssued
    {
        public Book Bk { get; set; }
        public Student1 Std { get; set; }
        public DateTime DtIssued { get; set; }
    }
    public class Student1
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
    }



