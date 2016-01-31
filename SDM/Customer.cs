namespace SDM
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Interfaces;

    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; }
        public Random CreateRandom { get; set; }

        public Customer(int customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
            Accounts = new List<IAccount>();
            CreateRandom = new Random();
        }

        public int NewAccountId()
        {
            var id = CreateRandom.Next(99999999, 999999999);
            if (Accounts != null)
            {
                return Accounts.Any(aid => aid.AccountId == id) ? NewAccountId() : id;
            }
            return id;
        }
    }
}
