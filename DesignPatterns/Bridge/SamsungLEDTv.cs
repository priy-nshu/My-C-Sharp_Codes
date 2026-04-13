using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public class SamsungLEDTv:ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON: SAMSUNG TV");
        }
        public void SwitchOff() { Console.WriteLine("Turning Off: SAMSUNG TV"); }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting Channel Number :" + channelNumber + " on Samsung TV");
        }
    }
}
