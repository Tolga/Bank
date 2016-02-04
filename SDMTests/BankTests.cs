using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM;
using SDM.Interfaces;

namespace Tests
{
    [TestClass()]
    public class BankTests
    {
        private IBank Bank1 { get; }
        private List<IAccount> Accounts { get; }

        private readonly Random _random  = new Random();

        public BankTests()
        {
            Bank1 = new Bank(1, "PKO");
            Accounts = new List<IAccount>();

            Bank1.Customers = new List<ICustomer> {
                new Customer(Bank1.NewCustomerId(), "Erika Klarsson"),
                new Customer(Bank1.NewCustomerId(), "Antony Incor")
            };

            Bank1.CreateAccounts();

            Accounts = Bank1.Customers.SelectMany(customer => customer.Accounts).ToList();
        }

        [TestMethod()]
        public void CreateAccountsTest()
        {
            Assert.IsNotNull(Accounts.ElementAt(_random.Next(0, Accounts.Count-1)));

            Accounts[0] = null;

            Assert.IsNull(Accounts.ElementAt(0));
        }

        [TestMethod()]
        public void NewCustomerIdTest()
        {
            CollectionAssert.AllItemsAreUnique(Bank1.Customers.Select(customer => customer.CustomerId).ToList());
        }
    }
}