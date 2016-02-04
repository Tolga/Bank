using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM;
using SDM.Interfaces;

namespace Tests
{
    /// <summary>
    /// Summary description for Customers
    /// </summary>
    [TestClass]
    public class Customers
    {
        private readonly List<ICustomer> _customers;
        private readonly IBank _bank;

        public Customers()
        {
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CustomersCount()
        {
            /*
            Assert.AreEqual(_customers.Count, 2);

            _customers.Add(new Customer(_bank,"Test 1"));

            Assert.AreEqual(_customers.Count, 3);

            _customers.Clear();

            _customers.Add(new Customer(_bank, "Test 2"));

            Assert.AreEqual(_customers.Count, 1);
            */
        }
    }
}
