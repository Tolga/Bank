using System;
using System.Collections.Generic;
using System.Linq;

namespace SDM
{
    using Interfaces;

    public class Bank : IBank
    {
        public Bank()
        {
            CreateRandom = new Random();
            InterestRates = new[] { 0.05F, 0.06F, 0.08F, 0.010F };

            /*
             * Create default data
             */
            Customers = new List<ICustomer>
            {
                new Customer(this, "Erik Klasson"),
                new Customer(this, "Mark Encor")
            };

            Accounts = new List<IAccount>();
            foreach (var customer in Customers)
            {
                Accounts.Add(new Account(this, customer.Id));
            }
        }

        public Random CreateRandom { get; set; }
        public float[] InterestRates { get; set; }
        public List<Operation> HistoryOfOperations { get; set; }
        public List<ICustomer> Customers { get; set; }
        public List<IAccount> Accounts { get; set; }
    }
}
