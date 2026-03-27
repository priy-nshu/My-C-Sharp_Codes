using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService
{
    [TestFixture(CustomerType.Premium,100.00)]
    [TestFixture(CustomerType.Basic)]
    public class CustomerOrderServiceTest2
    {
        private CustomerType customerTye;
        private double minOrder;

        public CustomerOrderServiceTest2(CustomerType customerTye, double minOrder)
        {
            this.customerTye = customerTye;
            this.minOrder = minOrder;
        }

        public CustomerOrderServiceTest2(CustomerType customerTye) : this(customerTye, 0)
        {

        }
        [TestCase]
        public void TestMethod()
        {
            Assert.That(true,Is.EqualTo((customerTye==CustomerType.Basic && minOrder==0 || customerTye==CustomerType.Premium && minOrder> 0)));
        }
        [TestCase(new int[] {2,4,6})]
        public void TestMethod2(int[] numbers) 
        { 
            MyNumber myNumber  = new MyNumber();
            bool result = myNumber.AreAllNumbersEven(numbers);

           // Assert.That(result, Is.True);
            Assert.That(false,Is.EqualTo(result));

        }


    }
}
