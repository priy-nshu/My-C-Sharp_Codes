using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    public class DarkCheckBox:ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a dark-themed checkbox");
        }
    }
}
