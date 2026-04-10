using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    public class AbstractFactoryClient
    {
        private readonly IButton button;
        private readonly ICheckbox checkbox;

        public AbstractFactoryClient(IUIFactory factory)
        {
            button = factory.CreateButton();
            checkbox= factory.CreateCheckBox();
        }

        public void Run()
        {
            button.Render();
            checkbox.Render();
        }
    }
}
