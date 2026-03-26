// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using BykeStoreConsoleApp.Services;

string str = System.Configuration.ConfigurationManager.ConnectionStrings["BykeCon"].ConnectionString;

BykeStoreDAL bykeStoreDAL = new BykeStoreDAL(str);
bykeStoreDAL.DisplayStaff();
