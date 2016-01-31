namespace SDM
{
    using System;

    class Bootstrapper
    {
        static void Main()
        {
            Bank bank = new Bank();
            foreach (var customer in bank.Customers)
            {
                foreach (var account in customer.Accounts)
                {
                    Console.WriteLine();
                    Console.WriteLine("CUSTOMER:");
                    Console.WriteLine();
                    Console.WriteLine("ID: {0} - NAME: {1}", customer.CustomerId, customer.Name);

                    if (account != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ACCOUNT:");
                        Console.WriteLine();
                        Console.WriteLine("ID: {0}", account.AccountId);
                        Console.WriteLine("BALANCE: {0} - INTEREST RATE: {1}", account.Balance, account.State.Check());
                        Console.WriteLine("OPENING DATE: " + account.OpenDate);
                        Console.WriteLine();
                        Console.WriteLine("DEBIT INFORMATION:");
                        Console.WriteLine();
                        Console.WriteLine("DEBIT LEFT: " + account.AllowedDebit);
                        Console.WriteLine();
                        Console.WriteLine("DEBIT AMOUNT:" + account.Debits);

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
                    Console.WriteLine("------------------------------------------------------------");
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

            Console.ReadLine();
        }
    }
}
