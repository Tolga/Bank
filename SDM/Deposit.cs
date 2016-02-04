using System.Linq;

namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

	public class Deposit : IOperation
    {
        public float Amount { get; set; }
        public DateTime EndDate { get; set; }
        public ICustomer Customer { get; set; }
        private IAccount DepositAccount { get; set; }
        private IAccount NormalAccount { get; set; }
        public List<IOperationHistory> History { get; set; }

        public Deposit (ICustomer customer, float amount, DateTime endDate)
        {
            Amount = amount;
            EndDate = endDate;
		    Customer = customer;
            History = new List<IOperationHistory>();
		}

	    // OpenDeposit
        public void Do()
        {
            NormalAccount = Customer.Accounts.First(a => a.Type == AccountType.Normal);

            if (NormalAccount != null)
            {
                if (NormalAccount.Balance >= Amount)
                {
                    NormalAccount.Balance -= Amount;
                    DepositAccount = new Account(Customer, AccountType.Deposit, Amount, EndDate);
                    Customer.Accounts.Add(DepositAccount);
                    History.Add(new OperationHistory("New deposit of " + Amount + " successfully created for Customer " + Customer.CustomerId, true, DateTime.Now));
                }
                else
                {
                    History.Add(new OperationHistory("New deposit of " + Amount + " failed for Customer " + Customer.CustomerId + ". Insufficient funds!", false, DateTime.Now));
                }
            }
            else
            {
                History.Add(new OperationHistory("New deposit of " + Amount + " failed for Customer " + Customer.CustomerId + ". Customer doesn't have a normal account!", false, DateTime.Now));
            }
        }

        // CloseDeposit
        public void Undo()
        {
            NormalAccount = Customer.Accounts.First(a => a.Type == AccountType.Normal);

            if (NormalAccount != null)
            {
                DepositAccount = Customer.Accounts.First(a => a.Type == AccountType.Deposit);

                if (DepositAccount != null)
                {
                    DepositAccount.State.Calculate();
                    NormalAccount.Balance += DepositAccount.Balance;
                    DepositAccount.Balance = 0;
                    History.Add(new OperationHistory("Closing deposit successful for Customer " + Customer.CustomerId, true, DateTime.Now));
                }
                else
                {
                    History.Add(new OperationHistory("Closing deposit failed for Customer " + Customer.CustomerId + ". Customer doesn't have a Deposit account!", false, DateTime.Now));
                }
            }
            else
            {
                History.Add(new OperationHistory("Closing deposit failed for Customer " + Customer.CustomerId + ". Customer doesn't have a Normal account!", false, DateTime.Now));
            }
        }
    }
}
