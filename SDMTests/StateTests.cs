using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM;
using SDM.Interfaces;

namespace Tests
{
    [TestClass]
    public class StateTests
    {
        private IBank Bank1 { get; }

        private readonly Random _random = new Random();

        public StateTests()
        {
            Bank1 = new Bank(1, "PKO");

            Bank1.Customers = new List<ICustomer> {
                new Customer(Bank1.NewCustomerId(), "Erika Klarsson"),
                new Customer(Bank1.NewCustomerId(), "Antony Incor")
            };

            Bank1.CreateAccounts();
        }

        [TestMethod]
        public void CalculateTest()
        {
            ICustomer customer1 = Bank1.Customers.First();

            customer1.Accounts.First().Balance = 1000;

            IOperation operation1 = new Operation(Operations.Deposit, new object[]{ customer1, 1000, DateTime.Now } );
            operation1.Do();
            operation1.Undo();

            Assert.AreEqual(customer1.Accounts.Last().History.Last().Details, "PENALTY");


            ICustomer customer2 = Bank1.Customers.Last();

            customer2.Accounts.First().Balance = 5000;

            IOperation operation2 = new Operation(Operations.Deposit, new object[] { customer2, 5000, DateTime.Now });
            operation2.Do();
            customer2.Accounts.Last().OpenDate = DateTime.Now.AddMonths(-13);
            operation2.Undo();

            Assert.AreEqual(customer2.Accounts.Last().History[1].Details, "PREMIUM");
        }

        [TestMethod]
        public void CheckTest()
        {
            ICustomer customer = Bank1.Customers.ElementAt(_random.Next(0, Bank1.Customers.Count - 1));
            IAccount account = customer.Accounts.First();

            Assert.IsInstanceOfType(account.State, typeof(Normal));

            account.Balance = 5000;

            Assert.IsInstanceOfType(account.State, typeof(Premium));

            account.Balance = 0;

            Assert.IsInstanceOfType(account.State, typeof(Normal));
        }
    }
}