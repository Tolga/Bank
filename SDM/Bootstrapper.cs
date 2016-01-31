namespace SDM
{
    using System;
    using Interfaces;

    class Bootstrapper
    {
        static void Main()
        {
            IBank bank1 = new Bank(1);
            IBank bank2 = new Bank(2);

            BankNetwork bankNetwork = new BankNetwork();
            bankNetwork.Register(bank1);
            bankNetwork.Register(bank2);

            bank1.Send(2, Commands.Transfer);

            foreach (var customer in bank1.Customers)
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

            foreach (var history in bank1.History)
            {
                Console.WriteLine("DESCRIPTION: " + history.Details);
                Console.WriteLine("DATE OF EXECUTION: " + history.DateOfExecution);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
