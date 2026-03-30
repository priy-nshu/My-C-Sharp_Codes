// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using BykeStoreConsoleApp.Models;
using BykeStoreConsoleApp.Services;

string str = System.Configuration.ConfigurationManager.ConnectionStrings["BykeCon"].ConnectionString;

BykeStoreDAL bykeStoreDAL = new BykeStoreDAL(str);
//bykeStoreDAL.DisplayStaff();
//bykeStoreDAL.DisplayCustomerAndStaff();
//Console.Write("Enter Customer ID: ");
//bykeStoreDAL.DisplayCustomerPhone(Convert.ToInt32(Console.ReadLine()));

//int result1 = bykeStoreDAL.InsertCustomer();
//if (result1 > 0)
//{
//    Console.WriteLine("Result inserted successfully");
//}
//else
//{
//    Console.WriteLine("Error: Retry");
//}


//int result2 = bykeStoreDAL.UpdateCustomerPhone();
//if (result2 > 0)
//{
//    Console.WriteLine("Result inserted successfully");
//}
//else
//{
//    Console.WriteLine("Error: Retry");
//}

//bykeStoreDAL.DeleteCustomerID();

static void DisplayStaffs(BykeStoreDAL bd)
{
    List<Staff> AllStaff = bd.GetStaff();
    if (AllStaff != null)
    {
        foreach (Staff s in AllStaff)
        {
            Console.WriteLine(s.staff_id + "," + s.first_name + ","+ s.last_name+ "\n");
        }
    }
}