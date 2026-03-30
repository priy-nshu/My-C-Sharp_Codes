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

<<<<<<< HEAD
        public LoginDetails(string password, string loginType)
=======
        public LoginDetails( string password, string loginType)
>>>>>>> ca973e6edfc4a47fab7f244dfc44b86289a76d21
        {
            Password = password;
            LoginType = loginType;

<<<<<<< HEAD
            if (loginType.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                LoginID = AdminID;
            }
            else
            {
                LoginID = (nextId++).ToString();
=======
            if (loginType.Equals("Admin", StringComparison.OrdinalIgnoreCase)) {
                LoginID = AdminID;            
            }
            else
            {
                LoginID =(nextId++).ToString();
>>>>>>> ca973e6edfc4a47fab7f244dfc44b86289a76d21
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
