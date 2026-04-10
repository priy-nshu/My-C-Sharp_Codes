// See https://aka.ms/new-console-template for more information
using DesignPatterns.AbstractFactory;
using DesignPatterns.Factory;
using DesignPatterns.Singleton;

Console.WriteLine("Hello World");
static void GetSingleton()
{
    var s1=MySingleton.getInstance();
    var s2=MySingleton.getInstance();
    var s3=MySingleton.getInstance();
}

static void getFactory()
{
    int choice;

    do
    {
        Console.WriteLine("\n--- Vehicle Factory Menu ---");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Truck");
        Console.WriteLine("3. Exit");
        Console.Write("Enter choice: ");

        choice = Convert.ToInt32(Console.ReadLine());

        VehicleFactory factory = new VehicleFactory();
        IVehicle vehicle = null;

        switch (choice)
        {
            case 1:
                vehicle = factory.CreateVehicle("car");
                break;

            case 2:
                vehicle = factory.CreateVehicle("truck");
                break;

            case 3:
                Console.WriteLine("Exiting...");
                return;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }

        if (vehicle != null)
        {
            vehicle.DisplayInfo();
        }

    } while (true);
}
//getFactory();

static void ArrFactory()
{
    VehicleFactory factory = new VehicleFactory();
   IVehicle[] vehicle = new IVehicle[] {factory.CreateVehicle("car"),  factory.CreateVehicle("truck") };

    foreach (var item in vehicle)
    {
        item.DisplayInfo();
    }
}
//ArrFactory();

static void getAbstract() { 

    IUIFactory factory;

    do
    {
        Console.WriteLine("\nSelect Theme:");
        Console.WriteLine("1. Light Theme");
        Console.WriteLine("2. Dark Theme");
        Console.Write("Enter choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            factory = new LightThemedFactory();
        }
        else if (choice == 2)
        {
            factory = new DarkThemedFactory();
        }
        else
        {
            Console.WriteLine("Invalid choice");
            return;
        }
        AbstractFactoryClient client = new AbstractFactoryClient(factory);
        client.Run();
    } while (true);            
}
getAbstract();