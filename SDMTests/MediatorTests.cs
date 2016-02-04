using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM;
using SDM.Interfaces;

namespace Tests
{
    [TestClass]
    public class MediatorTests
    {
        private IBank Bank1 { get; }
        private IBank Bank2 { get; }
        private IBankNetwork BankNetwork { get; }

        public MediatorTests()
        {
            Bank1 = new Bank(1, "PKO");
            Bank2 = new Bank(2, "WBK");

            Bank1.Customers = new List<ICustomer> {
                new Customer(Bank1.NewCustomerId(), "Erika Klarsson"),
                new Customer(Bank1.NewCustomerId(), "Antony Incor")
            };

            Bank1.CreateAccounts();

            Bank2.Customers = new List<ICustomer>
            {
                new Customer(Bank2.NewCustomerId(), "Kevin Enderson"),
                new Customer(Bank2.NewCustomerId(), "Richord Matthew")
            };

            Bank2.CreateAccounts();

            BankNetwork = new BankNetwork();
            BankNetwork.Register(Bank1);
            BankNetwork.Register(Bank2);
        }

        [TestMethod]
        public void RegisterTest()
        {
            CollectionAssert.Contains(BankNetwork.Banks.Values, Bank1);
            CollectionAssert.Contains(BankNetwork.Banks.Values, Bank2);
        }

        [TestMethod]
        public void SendTest()
        {
            Bank1.Customers.First().Accounts.First().Balance = 75;
            Bank1.Send(Bank1.Customers.First(), Bank2.Customers.Last(), 50);

            Assert.AreEqual(Bank1.Customers.First().Accounts.First().Balance, 25);
            Assert.AreEqual(Bank2.Customers.Last().Accounts.First().Balance, 50);
        }
    }
}