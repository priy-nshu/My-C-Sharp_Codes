using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    public class Observer:IObserver
    {
        public string UserName { get; set; }
        public Observer(string UserName)
        {
            this.UserName = UserName;
        }

        public void AddSubscriber(ISubject subject)
        {
            subject.RegisterObserver(this);
        }
        public void RemoveObserver(ISubject subject)
        {
            subject.RemoveObserver(this);
        }

        public void Update(string availibility)
        {
            Console.WriteLine("Hello "+UserName+", Product is now"+ availibility+" on Amazon");
        }
    }
}
