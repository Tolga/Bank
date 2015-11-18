using System;
using System.Linq;

namespace SDM
{
    class Bootstrapper
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            foreach (var customer in bank.Customers)
            {
                var account = bank.Accounts.SingleOrDefault(aid => aid.CustomerId == customer.Id);

                Console.Write("\n");
                Console.WriteLine("CUSTOMER:");
                Console.WriteLine("ID: {0} - NAME: {1}", customer.Id, customer.Name);
                Console.Write("\n");
                Console.WriteLine("ACCOUNT:");
                Console.WriteLine("ID: {0} - TYPE: {1}", account.Id, account.Type);
                Console.WriteLine("BALANCE: {0} - INTEREST RATE: {1}", account.Balance, account.InterestRate);
                Console.WriteLine("OPENING DATE: {0}", account.OpeningDate);
                Console.Write("\n");
                Console.WriteLine("-----------------------------------");
            }

            Console.ReadLine();
        }
    }
}
