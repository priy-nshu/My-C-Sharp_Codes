using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    public class DarkThemedFactory:IUIFactory
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }
        public ICheckbox CreateCheckBox()
        {
            return new DarkCheckBox();
        }
    }
}
