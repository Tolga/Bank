namespace SDM
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Interfaces;

    public class Bank : IBank
    {
        public int BankId { get; set; }
        public IBankNetwork BankNetwork { get; set; }
        public float Balance { get; set; }
        public List<ICustomer> Customers { get; set; }
        public List<IOperationHistory> History { get; set; }
        public Random CreateRandom { get; set; }

        public Bank(int bankId)
        {
            BankId = bankId;
            History = new List<IOperationHistory>();
            CreateData();
        }
        
        // ToDo: Add CustomerNumber to Receive an Send

        // Receives command from given bank
        public virtual void Receive(int from, Commands command, int amount)
        {
            Console.WriteLine("{0} to {1}: '{2}' of {3}", from, BankId, command, amount);
        }

        // Sends command to given bank
        public void Send(int to, Commands command, int amount)
        {
            BankNetwork.Send(BankId, to, command, amount);
        }

        private void CreateData()
        {
            CreateRandom = new Random();

            // Create Customers
            Customers = new List<ICustomer>
            {
                new Customer(NewCustomerId(), "Erik Klasson"),
                new Customer(NewCustomerId(), "Mark Encor")
            };

            // Create Accounts for Customers
            foreach (var customer in Customers)
            {
                customer.Accounts.Add(new Account(customer));
            }

            // Create a new debit of 100 for Customer1
            IOperation customer1Debit = new Operation(Commands.Debit, new object[] { 170, Customers[0].Accounts[0] });
            customer1Debit.Do();
            History.AddRange(customer1Debit.History);

            // Transfer 40 from Customer1 to Customer2 then Undo it and then do it again
            IOperation pay = new Operation(Commands.Transfer, new object[] { 40, Customers[0].Accounts[0], Customers[1].Accounts[0] });
            pay.Do();
            pay.Undo();
            pay.Do();
            History.AddRange(pay.History);

            // Create a new debit of 150 Zl for Customer2
            IOperation customer2Debit = new Operation(Commands.Debit, new object[] { 100, Customers[1].Accounts[0] });
            customer2Debit.Do();
            History.AddRange(customer2Debit.History);

            // Create a new deposit of 140 Zl for Customer2
            IOperation customer2Deposit = new Operation(Commands.Deposit, new object[] { Customers[1], 140, DateTime.Now.AddYears(1) });
            customer2Deposit.Do();
            History.AddRange(customer2Deposit.History);
        }

        private int NewCustomerId()
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
