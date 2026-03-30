

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.Write("Hello,");
Console.Write("World!\n");
//PrintDate();
//PrintEnums();

//StringFunctions strf=new StringFunctions();
//strf.AcceptandPrint();
//strf.MoreStringFunctions();


//SimpleTasks SimpleTasks = new SimpleTasks();
//SimpleTasks.Reader();
//SimpleTasks.FindGreatest();
//SimpleTasks.First10Primes();
//Singleton_DEMO.getInstance();
//int indexer = 0;
//while (indexer < 100)
//{
//    indexer+=10;
//}
//Singleton_DEMO.getInstance();
//int A=50;
//SimpleTasks.Sum(ref A);
//Console.WriteLine(A);

//SimpleArray SimpleArray = new SimpleArray();
//SimpleArray.AcceptandPrint();
//SimpleArray.TwoDArray();

//Test test = new Test();
//test.CallisTest();

//ShapeTester shape = new ShapeTester();
//shape.TestShapes();

//Transaction transaction = new Transaction();
//transaction.showTransaction();

CTransaction Ctransaction = new CTransaction();
Ctransaction.showTransaction();


/*static void PrintDate(){
    String dateString = "05/01/1995";
    Console.WriteLine("Date: "+Convert.ToDateTime(dateString));

    dateString = "Apr-28-2008";
    Console.WriteLine("Date: " + Convert.ToDateTime(dateString));

    dateString = "May-29-2018";
    Console.WriteLine($"Date: {Convert.ToDateTime(dateString)}");

    dateString = "06 July 2008 7:32:47 AM";
    Console.WriteLine("Date: " + Convert.ToDateTime(dateString));

    dateString = "17:32:47.003";
    Console.WriteLine("Date: " + Convert.ToDateTime(dateString));

    // dateString = "Tue Apr 28,2008";                               The formatting is wrong here
    //Console.WriteLine("Date: " + Convert.ToDateTime(dateString));

}


static void PrintEnums()
{
    Console.WriteLine("Today is :" + DayOfWeek.Monday);
    Console.WriteLine("Monday is: " + (int)DayOfWeek.Monday);
    string[] values = Enum.GetNames(typeof(DayOfWeek));
    Console.WriteLine("No of String Elements" + values.Length);
    int[] n = (int[])Enum.GetValues(typeof(DayOfWeek));
    Console.WriteLine("No of numeric elements:" + n.Length);
}


public enum DayOfWeek
{
    Sunday=1,Monday=2,Tuesday=3,Wednesday=4,Thursday=5, Friday=6,Saturday
}
*/