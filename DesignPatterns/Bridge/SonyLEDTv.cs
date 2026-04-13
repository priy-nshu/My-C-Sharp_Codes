using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public class SonyLEDTv:ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON: SONY TV");
        }
        public void SwitchOff() { Console.WriteLine("Turning Off: SONY TV"); }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting Channel Number :" + channelNumber + " on Sony TV");
        }
    }
}
