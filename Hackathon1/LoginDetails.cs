using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    internal class LoginDetails
    {
        static string AdminID = "MOVIEADMIN";
        static int nextId = 1000;

        public string LoginID { get; set; }
        public string Password { get; set; }
        public string LoginType { get; set; }

        public LoginDetails( string password, string loginType)
        {
            Password = password;
            LoginType = loginType;

            if (loginType.Equals("Admin", StringComparison.OrdinalIgnoreCase)) {
                LoginID = AdminID;            
            }
            else
            {
                LoginID =(nextId++).ToString();
            }
        }
        public void DisplayLoginDetails()
        {
            Console.WriteLine("----Login Details----");
            Console.WriteLine($"Login ID   :{LoginID}");
            Console.WriteLine($"Login Type :{LoginType}");
        }
    }
}
