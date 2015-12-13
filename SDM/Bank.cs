namespace SDM
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Interfaces;

    public class Bank : IBank
    {
        public Random CreateRandom { get; set; }
        public float Balance { get; set; }
        public float[] InterestRates { get; set; }
        public List<ICustomer> Customers { get; set; }
        public List<IOpHistory> History { get; set; }

        public Bank()
        {
            History = new List<IOpHistory>();
            CreateData();
        }

        private void CreateData()
        {
            CreateRandom = new Random();

            // Create Customers
            Customers = new List<ICustomer>
            {
                new Customer(NewId("Customer"), "Erik Klasson"),
                new Customer(NewId("Customer"), "Mark Encor")
            };

            // Create Accounts for Customers
            foreach (var customer in Customers)
                customer.Accounts.Add(new Account(NewId("Account"), customer.Id));

            // Transfer 40 Zl then Undo it
            ICommand pay = new Operation(Commands.Pay, new object[] {40, Customers[0].Accounts[0], Customers[1].Accounts[0]}).Commit();
            pay.Do();
            pay.Undo();
            History.AddRange(pay.History);

            // Create a new debit of 150 Zl
            ICommand debit = new Operation(Commands.Debit, new object[] {150, Customers[1].Accounts[0]}).Commit();
            debit.Do();
            History.AddRange(debit.History);
        }

        /// <summary>
        /// Creates a new id, checks if ID is unique to given type. If not then creates another one.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private int NewId(string type = null)
        {
            var id = CreateRandom.Next(99999999, 999999999);
            if (type != null)
                switch (type)
                {
                    case "Customer":
                        if (Customers != null)
                            return (Customers.SingleOrDefault(cid => cid.Id == id) != null) ? NewId("Customer") : id;
                        break;
                    case "Account":
                        if (Customers.FirstOrDefault(a => a.Accounts.Any(aid => aid.Id == id)) != null)
                            return (Customers.First(a => a.Accounts.Any(aid => aid.Id == id)) != null) ? NewId("Account") : id;
                        break;
                }
            return id;
        }
    }
}
