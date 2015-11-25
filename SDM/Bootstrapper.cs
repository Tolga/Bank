namespace SDM
{
    using System;
    using System.Linq;

    class Bootstrapper
    {
        static void Main()
        {
            Bank bank = new Bank();
            foreach (var customer in bank.Customers)
            {
                var account = customer.Accounts.Single(aid => aid.CustomerId == customer.Id);

                Console.WriteLine();
                Console.WriteLine("CUSTOMER:");
                Console.WriteLine();
                Console.WriteLine("ID: {0} - NAME: {1}", customer.Id, customer.Name);

                if (account != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("ACCOUNT:");
                    Console.WriteLine();
                    Console.WriteLine("ID: {0} - TYPE: {1}", account.Id, account.Type);
                    Console.WriteLine("BALANCE: {0} - INTEREST RATE: {1}", account.Balance, account.InterestRate);
                    Console.WriteLine("OPENING DATE: " + account.OpeningDate);
                    Console.WriteLine();
                    Console.WriteLine("DEBIT INFORMATION:");
                    Console.WriteLine();
                    Console.WriteLine("DEBIT LIMIT: " + account.AllowedDebit + account.Type);
                    Console.WriteLine();
                    Console.WriteLine("CURRENT DEBITS:");
                    if (account.Debits.Count > 0)
                    {
                        foreach (var debit in account.Debits)
                        {
                            Console.WriteLine();
                            Console.WriteLine("AMOUNT: " + debit.Amount + account.Type);
                            Console.WriteLine("DATE TIME: " + debit.History.DateOfExecution);
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("NO DEBITS!");
                    }
                    Console.WriteLine();
                    Console.WriteLine("HISTORY OF OPERATIONS:");
                    foreach (var history in account.History)
                    {
                        Console.WriteLine();
                        Console.WriteLine("DESCRIPTION: " + history.Description);
                        Console.WriteLine("DATE TIME: " + history.DateOfExecution);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------");
            }

            Console.WriteLine();
            Console.WriteLine("BANK'S HISTORY OF OPERATIONS:");
            Console.WriteLine();

            foreach (var history in bank.Operations.History)
            {
                Console.WriteLine("DESCRIPTION: " + history.Description);
                Console.WriteLine("DATE OF EXECUTION: " + history.DateOfExecution);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
