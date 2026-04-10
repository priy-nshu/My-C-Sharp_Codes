// See https://aka.ms/new-console-template for more information
using DesignPatterns.Singleton;

static void GetSingleton()
{
    var s1=MySingleton.getInstance();
    var s2=MySingleton.getInstance();
}