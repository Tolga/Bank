using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM;
using SDM.Interfaces;

namespace Tests
{
    /// <summary>
    /// Summary description for Accounts
    /// </summary>
    [TestClass]
    public class Accounts
    {
        private readonly IBank _bank;

        public Accounts()
        {
            _bank = new Bank();
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
        public void AccountsCount()
        {
            /*
            Assert.AreEqual(_accounts.Count, 2);

            _accounts.Clear();

            _customers.Add(new Customer(1, "Test 1"));

            foreach (var customer in _customers)
            {
                _accounts.Add(new Account(1, customer.Id));
            }

            Assert.AreEqual(_accounts.Count, 3);

            _accounts.Clear();
            _customers.Clear();

            _customers.Add(new Customer(_bank, "Test 2"));

            foreach (var customer in _customers)
            {
                _accounts.Add(new Account(_bank, customer.Id));
            }

            Assert.AreEqual(_accounts.Count, 1);
            */
        }
    }
}
