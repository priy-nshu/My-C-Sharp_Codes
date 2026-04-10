using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    public class LightThemedFactory:IUIFactory
    {
        public IButton CreateButton()
        {
            return new LightButon();
        }
        public ICheckbox CreateCheckBox()
        {
            return new LightCheckBox();
        }
    }
}
