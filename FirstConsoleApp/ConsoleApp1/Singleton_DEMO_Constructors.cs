using System;


internal class Singleton_DEMO
{
    private static string CreatedON;
    private static Singleton_DEMO instance = null;

    private Singleton_DEMO()
    {
        CreatedON = DateTime.Now.ToLongTimeString();
    }
    public static Singleton_DEMO getInstance()
    {
        if (instance == null)
        {
            instance = new Singleton_DEMO();
        }
        Console.WriteLine(CreatedON);
        return instance;
    }
}

