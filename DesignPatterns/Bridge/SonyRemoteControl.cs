using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public class SonyRemoteControl:AbstractRemoteControl
    {
        public SonyRemoteControl(ILEDTV LEDTV)
        {
            this.LEDTV = LEDTV;
        }
        public override void SwitchOn()
        {
            LEDTV.SwitchOn();
        }
        public override void SwitchOff()
        {
            LEDTV.SwitchOff();
        }

        public override void SetChannel(int channelNumber)
        {
            LEDTV.SetChannel(channelNumber);
        }
    }
}
