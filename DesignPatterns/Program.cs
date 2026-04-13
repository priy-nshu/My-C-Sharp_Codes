// See https://aka.ms/new-console-template for more information
using DesignPatterns.AbstractFactory;
using DesignPatterns.Bridge;
using DesignPatterns.Builder;
using DesignPatterns.Factory;
using DesignPatterns.Observer;
using DesignPatterns.Singleton;

Console.WriteLine("Hello World");
static void GetSingleton()
{
    var s1=MySingleton.getInstance();
    var s2=MySingleton.getInstance();
    var s3=MySingleton.getInstance();
}//GetSingleton

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
//getAbstract();

static void BuildMyCar()
{
    ICarBuilder builder = new CarBuilder();

    Car myCar = builder
        .SetEngine("Some Maruti")
        .SetColor("Tamarind")
        .SetWheels(14)
        .SetSeats(7)
        .Build();

    myCar.display();
}//BuildMyCar();

static void MyObserver()
{
    Subject RedMI = new Subject("RedMI ", 10000, " Out Of Stock");

    Observer user1 = new Observer("Priyanshu");
    Observer user2 = new Observer("Akshay");
    Observer user3 = new Observer("Pratyasha");

    user1.AddSubscriber(RedMI);
    user2.AddSubscriber(RedMI);
    user3.AddSubscriber(RedMI);

    Console.WriteLine("RedMI mobile current state: " + RedMI.GetAvailabilty());
    Console.WriteLine();

    user3.RemoveObserver(RedMI);

    RedMI.setAvailibility(" Available");
    Console.Read();
}//MyObserver();

    static void MyBridge()
    {

        Console.WriteLine("Select TV Brand:");
        Console.WriteLine("1. Samsung");
        Console.WriteLine("2. Sony");
        Console.Write("Enter choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        AbstractRemoteControl remote;

        switch (choice)
        {
            case 1:
                var samsungTv = new SamsungLEDTv();
                remote = new SamsungRemoteControl(samsungTv);
                break;

            case 2:
                var sonyTv = new SonyLEDTv();
                remote = new SonyRemoteControl(sonyTv);
                break;

            default:
                Console.WriteLine("Invalid choice");
                return;
        }

        // ✅ Use remote
        remote.SwitchOn();
        remote.SetChannel(101);
        remote.SwitchOff();

        Console.ReadLine();
    }
MyBridge();