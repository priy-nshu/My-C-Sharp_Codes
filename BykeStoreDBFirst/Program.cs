// See https://aka.ms/new-console-template for more information
<<<<<<< HEAD
using BykeStoreDBFirst.Models;
using BykeStoreDBFirst.Services;

Console.WriteLine("Hello, World!");
//connectionString = "Server=EC2AMAZ-EHR6SVV;Initial Catalog=BykeStores;Integrated Security=True;Persist Security Info=False;Encrypt=False" providerName = "Microsoft.Data.SqlClient" />

AddCustomer();

static void AddCustomer()
{
    Customer customer = new Customer();

    Console.WriteLine("Enter Data for new Customer:");
    Console.Write("Customer First Name: ");
    customer.FirstName = Console.ReadLine();
    Console.Write("Customer Last Name: ");
    customer.LastName = Console.ReadLine();

    Console.Write("Enter Phone: ");
    customer.Phone = Console.ReadLine();

    Console.Write("Enter Email: ");
    customer.Email = Console.ReadLine();

    Console.Write("Enter Street: ");
    customer.Street = Console.ReadLine();

    Console.Write("Enter City: ");
    customer.City = Console.ReadLine();

    Console.Write("Enter State: ");
    customer.State = Console.ReadLine();

    Console.Write("Enter Zip Code: ");
    customer.ZipCode = Console.ReadLine();

    BykeStoreDAL bDAL = new BykeStoreDAL();
    int recAdded = bDAL.AddCustomer(customer);

    if (recAdded > 0)
    {
        Console.WriteLine($"{recAdded} record added successfully");
    }
    else
    {
        Console.WriteLine("Something went wrong");
    }
}
static void UpdateCustomer()
{
    BykeStoreDAL bDAL = new BykeStoreDAL();

    Console.WriteLine("Enter Customer ID to update: ");
    int custID = Convert.ToInt32(Console.ReadLine());
    Customer customer = bDAL.GetCustomerById(custID);

    if (customer != null)
        Console.WriteLine($"Customer Id: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}\n");
    else
    {
        Console.WriteLine("No record found");
        return;
    }

    Console.WriteLine("Enter new First Name: ");
    customer.FirstName = Console.ReadLine();
    Console.WriteLine("Enter new Last Name: ");
    customer.LastName = Console.ReadLine();

    Console.WriteLine("Enter new Phone: ");
    customer.Phone = Console.ReadLine();

    Console.WriteLine("Enter new Email: ");
    customer.Email = Console.ReadLine();

    Console.WriteLine("Enter new Street: ");
    customer.Street = Console.ReadLine();

    Console.WriteLine("Enter new City: ");
    customer.City = Console.ReadLine();

    Console.WriteLine("Enter new State: ");
    customer.State = Console.ReadLine();

    Console.WriteLine("Enter new Zip Code: ");
    customer.ZipCode = Console.ReadLine();

    int recUpdated = bDAL.UpdateCustomer(customer);

    if (recUpdated > 0)
    {
        Console.WriteLine($"{recUpdated} record updated successfully");
    }
    else
    {
        Console.WriteLine("Update failed or no changes detected");
    }
}
static void DeleteCustomer()
{
    BykeStoreDAL bDAL = new BykeStoreDAL();

    Console.WriteLine("Enter Customer ID to delete: ");
    int custID = Convert.ToInt32(Console.ReadLine());
    Customer customer = bDAL.GetCustomerById(custID);

    if (customer != null)
        Console.WriteLine($"Customer Id: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}");
    else
    {
        Console.WriteLine("No record found");
        return;
    }

    Console.WriteLine("Do you want to delete this record Y/N?");
    char choice = Convert.ToChar(Console.ReadLine());

    if (choice == 'y' || choice == 'Y')
    {
        int result = bDAL.DeleteCustomer(customer);

        if (result > 0)
        {
            Console.WriteLine("Successfully Deleted");
        }
        else
        {
            Console.WriteLine("Deletion failed or no changes detected");
        }
    }
}


=======
//Console.WriteLine("Hello, World!");
>>>>>>> ca973e6edfc4a47fab7f244dfc44b86289a76d21
