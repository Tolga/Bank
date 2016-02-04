using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM;
using SDM.Interfaces;

namespace Tests
{
    [TestClass]
    public class DebitTests
    {
        private IBank Bank1 { get; }
        private ICustomer Customer { get; }
        private IAccount Account { get; }
        private IOperation Operation { get; }

        private readonly Random _random = new Random();

        public DebitTests()
        {
            Bank1 = new Bank(1, "PKO");

            Bank1.Customers = new List<ICustomer> {
                new Customer(Bank1.NewCustomerId(), "Erika Klarsson"),
                new Customer(Bank1.NewCustomerId(), "Antony Incor")
            };

            Bank1.CreateAccounts();

            Customer = Bank1.Customers.ElementAt(_random.Next(0, Bank1.Customers.Count - 1));
            Account = Customer.Accounts.First();

            Operation = new Operation(Operations.Debit, new object[] { 250, Account });
        }

        [TestMethod]
        public void DoTest()
        {
            Operation.Do();
            Assert.AreEqual(Account.Balance, 250);
        }

        [TestMethod]
        public void UndoTest()
        {
            Operation.Do();
            Assert.AreEqual(Account.Balance, 250);

            Operation.Undo();
            Assert.AreEqual(Account.Balance, 0);
        }
    }
}