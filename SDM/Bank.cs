using System.Linq;

namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Bank : IBank
    {
        public Bank()
        {
            CreateData();
        }

        private void CreateData()
        {
            Operations = new Operation();
            CreateRandom = new Random();

            Customers = new List<ICustomer>
            {
                new Customer(NewId(), "Erik Klasson"),
                new Customer(NewId(), "Mark Encor")
            };

            foreach (var customer in Customers)
                customer.Accounts.Add(new Account(NewId(), customer.Id));

            Operations.Commit(Commands.Pay, new object[] {20, Customers[0].Accounts[0], Customers[1].Accounts[0]}).Execute();
            Operations.Commit(Commands.Debit, new object[] {195, Customers[1].Accounts[0]}).Execute();
        }

        /*
         * Creates a new id, check if is there any other customer with same id. If there is then try another one.
         * ToDo: Provide id creation for Accounts as well to check both to assure uniqness of id!
         */
        private int NewId()
        {
            var id = CreateRandom.Next(99999999, 999999999);
            if (Customers != null)
                return (Customers.SingleOrDefault(cid => cid.Id == id) != null) ? NewId() : id;
            return id;
        }

        public Random CreateRandom { get; set; }
        public float Balance { get; set; }
        public float[] InterestRates { get; set; }
        public List<ICustomer> Customers { get; set; }
        public IOperation Operations { get; set; }
    }
}
