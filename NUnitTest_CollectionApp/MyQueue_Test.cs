using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
namespace NUnitTest_CollectionApp
{
    [TestFixture]
    public class MyQueue_Test
    {
        private StringWriter sw;
        MyQueue queue;

        [SetUp]
        public void Initialize()
        {
            sw= new StringWriter();
            queue = new MyQueue();
        }
        [TearDown]
        public void Cleanup()
        {
            sw.Dispose();
        }
        [TestCase]
        public void ExpectedQueueBehaviour_Test()
        {
            queue.AcceptandPrint();
            string output = sw.ToString();

            Assert.That(output, Does.Contain("All Generic Queue Element count: 5"));
            Assert.That(output, Does.Contain("Dequeued Element: 10"));
            Assert.That(output, Does.Contain("Is Value 40 present in the queue: True"));
            Assert.That(output, Does.Contain("Is Value 90 present in the queue: False"));
            Assert.That(output, Does.Contain("CallerId contains 4"));
            Assert.That(output, Does.Contain("Copied Queue"));
        }

    }
}
