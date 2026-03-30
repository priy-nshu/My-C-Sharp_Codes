using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture(CustomerType.Premium,100,TypeArgs =new Type[] {typeof(CustomerType),typeof(double)})]
public class GenericTest<T1,T2>
{
    private T1 customerType;
    private T2 minOrder;

    public GenericTest(T1 customerType, T2 minOrder)
    {
        this.customerType = customerType;
        this.minOrder = minOrder;
    }
    [TestCase(Author ="Tek Systems")]
    public void TestMethod()
    {
        Assert.That(customerType, Is.InstanceOf<CustomerType>());
        Assert.That(minOrder,Is.InstanceOf<double>());
    }
}
