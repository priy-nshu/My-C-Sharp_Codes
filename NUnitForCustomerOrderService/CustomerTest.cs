using NUnit.Framework;

namespace NUnitForCustomerOrderService
{
    [TestFixture]
    public class CustomerTest
    {
        public Customer cs;
        [SetUp]
        public void InitilizeCustomers()        //Arrange
        {
           cs = new Customer();
        }
        [TestCase]
        public void when_AgeOver60_SeniorTrue()     //Act
        {
            cs.Age = 61;
            bool result =cs.IsSeniorCitizen();
            Assert.That(true, Is.EqualTo(result));
        }
        [TestCase]
        public void when_AgeBelow60_SeniorTrue()     //Act
        {
            cs.Age = 59;
            bool result = cs.IsSeniorCitizen();
            Assert.That(false, Is.EqualTo(result));
        }

        [TestCase(10,ExpectedResult =false)]
        [TestCase(80,ExpectedResult =true)]
        [TestCase(90,ExpectedResult =true)]

        public bool When_AgeGreaterOrEqualTo60_Expects_IsSeniorCitizenAsTrue(int age)
        {
            cs.Age = age;
            bool result = cs.IsSeniorCitizen();
            return result;
        }
      
    }
}
