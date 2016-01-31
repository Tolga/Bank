namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

	public class Loan : IOperation
    {
        public float Amount { get; set; }
        public float MontlyCost { get; set; }
	    public IAccount Account { get; set; }
	    public List<IOperationHistory> History { get; set; }

        public Loan(float amount, IAccount account)
        {
            Account = account;
            Amount = amount;
            History = new List<IOperationHistory>();
        }

        // Open Loan Account
        public void Do()
        {
            Account.Balance += Amount;
            MontlyCost += Amount;
            Amount += Amount;
            Account.History.Add(new OperationHistory("New Loan " + Amount + " on Account: " + Account.AccountId, true, DateTime.Now));
        }

        // Close Loan Account
        public void Undo()
        {
            Account.Balance -= Amount;
            MontlyCost -= Amount;
            Amount -= Amount;
            Account.History.Add(new OperationHistory("Loan Cancelled " + Amount + " on Account: " + Account.AccountId, true, DateTime.Now));
        }
    }
}

