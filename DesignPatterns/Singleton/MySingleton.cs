using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class MySingleton
    {
        private static string CreatedOn;
        private static MySingleton instance=null;

        private MySingleton()
        {
            CreatedOn = DateTime.Now.ToLongTimeString();
        }

        public static MySingleton getInstance()
        {
            if(instance == null)
            {
                instance = new MySingleton();
            }
            Console.WriteLine(CreatedOn);
            return instance;
        }
    }
}
