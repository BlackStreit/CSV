using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSV;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var items = JobItems.LoadFile(@"C:\Users\�������������\source\repos\CSV\007_��������� �������.csv");
            Assert.AreEqual(items.Count, 12527);
        }
    }
}
