namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

	public class Credit : ICommand
    {
        public Commands Command { get; set; }
        public float Amount { get; set; }
        public float MontlyCost { get; set; }
        public float InterestRate { get; set; }
	    public IAccount Account { get; set; }
	    public List<IOpHistory> History { get; set; }

        public Credit(float amount, IAccount account)
        {
            Account = account;
            Amount = amount;
            History = new List<IOpHistory>();
        }

        public void Do()
        {
            Account.Balance += Amount;
            MontlyCost += Amount;
            Amount += Amount;
            Account.History.Add(new OpHistory("New Loan " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
        }
        public void Undo()
        {
            Account.Balance -= Amount;
            MontlyCost -= Amount;
            Amount -= Amount;
            Account.History.Add(new OpHistory("Loan Cancelled " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
        }
    }
}

