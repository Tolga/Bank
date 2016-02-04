namespace SDM
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Interfaces;

    public class Bank : IBank
    {
        public int BankId { get; set; }
        public string Name { get; set; }
        public IBankNetwork BankNetwork { get; set; }
        public float Balance { get; set; }
        public List<ICustomer> Customers { get; set; }
        public List<IOperationHistory> History { get; set; }
        public Random CreateRandom { get; set; }

        public Bank(int bankId, string name)
        {
            BankId = bankId;
            Name = name;
            CreateRandom = new Random();
            History = new List<IOperationHistory>();
        }

        // Receives command from given bank
        public virtual void Receive(ICustomer from, ICustomer to, float amount)
        {
            to.Accounts.First().Balance += amount;
        }

        // Sends command to given bank
        public void Send(ICustomer from, ICustomer to, float amount)
        {
            from.Accounts.First().Balance -= amount;
            BankNetwork.Send(from, to, amount);
        }

        public void CreateAccounts()
        {
            // Create Accounts for Customers
            foreach (var customer in Customers)
            {
                customer.Accounts.Add(new Account(customer));
            }
            
            /*
            // Create a new debit of 100 for Customer1
            IOperation customer1Debit = new Operation(Operations.Debit, new object[] { 170, Customers[0].Accounts[0] });
            customer1Debit.Do();
            History.AddRange(customer1Debit.History);

            // Transfer 40 from Customer1 to Customer2 then Undo it and then do it again
            IOperation pay = new Operation(Operations.Transfer, new object[] { 40, Customers[0].Accounts[0], Customers[1].Accounts[0] });
            pay.Do();
            pay.Undo();
            pay.Do();
            History.AddRange(pay.History);

            // Create a new debit of 150 for Customer2
            IOperation customer2Debit = new Operation(Operations.Debit, new object[] { 100, Customers[1].Accounts[0] });
            customer2Debit.Do();
            History.AddRange(customer2Debit.History);

            // Create a new deposit of 140 for Customer2
            IOperation customer2Deposit = new Operation(Operations.Deposit, new object[] { Customers[1], 140, DateTime.Now.AddYears(1) });
            customer2Deposit.Do();
            History.AddRange(customer2Deposit.History);
            */
        }

        public int NewCustomerId()
        {
            var id = CreateRandom.Next(99999999, 999999999);
            if (Customers != null)
            {
                return Customers.Any(cid => cid.CustomerId == id) ? NewCustomerId() : id;
            }
            return id;
        }
    }
}
