using System.Collections.Generic;
using System.Linq;

namespace SDM
{
    using System;
    using Interfaces;

    class Bootstrapper
    {
        static void Main()
        {
            /*
            IBank bank1 = new Bank(1, "PKO");
            bank1.Customers = new List<ICustomer> { new Customer(bank1.NewCustomerId(), "Erika Klarsson"), new Customer(bank1.NewCustomerId(), "Antony Incor") };
            bank1.CreateAccounts();

            IOperation operation = new Operation(Operations.Debit, new object[]{ 75, bank1.Customers.First().Accounts.First() });
            operation.Do();

            IBank bank2 = new Bank(2, "Zachodni WBK");
            bank2.Customers = new List<ICustomer> { new Customer(bank2.NewCustomerId(), "Kevin Enderson"), new Customer(bank2.NewCustomerId(), "Richord Matthew") };
            bank2.CreateAccounts();

            IBankNetwork bankNetwork = new BankNetwork();
            bankNetwork.Register(bank1);
            bankNetwork.Register(bank2);

            bank1.Send(bank1.Customers.First(), bank2.Customers.Last(), 50);

            foreach (var bank in bankNetwork.Banks.Values)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("BANK: " + bank.Name);
                Console.WriteLine("----------------------------------------");

                foreach (var customer in bank.Customers)
                {
                    Console.WriteLine();
                    Console.WriteLine("CUSTOMER:");
                    Console.WriteLine("ID: {0} - NAME: {1}", customer.CustomerId, customer.Name);

                    foreach (var account in customer.Accounts)
                    {
                        if (account != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("ACCOUNT:");
                            Console.WriteLine("ID: {0}", account.AccountId);
                            Console.WriteLine("BALANCE: {0} - INTEREST RATE: {1}", account.Balance, account.State.Check());
                            Console.WriteLine("OPENING DATE: " + account.OpenDate);
                            Console.WriteLine();
                            Console.WriteLine("DEBIT INFORMATION:");
                            Console.WriteLine("LEFT: " + account.AllowedDebit);
                            Console.WriteLine("USED: " + account.Debits);

                            Console.WriteLine();
                            Console.WriteLine("HISTORY OF OPERATIONS:");

                            foreach (var history in account.History)
                            {
                                Console.WriteLine();
                                Console.WriteLine("DESCRIPTION: " + history.Details);
                                Console.WriteLine("DATE TIME: " + history.DateOfExecution);
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("BANK'S HISTORY OF OPERATIONS:");
                Console.WriteLine();

                foreach (var history in bank.History)
                {
                    Console.WriteLine("DESCRIPTION: " + history.Details);
                    Console.WriteLine("DATE OF EXECUTION: " + history.DateOfExecution);
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
            }

            Console.ReadLine();*/
        }
    }
}
