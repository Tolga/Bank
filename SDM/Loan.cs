using System.Collections.Generic;

namespace SDM
{
    using System;
	using Interfaces;

	public class Loan : ILoan, IOperation
	{
        public float Amount { get; set; }
        public float MontlyCost { get; set; }
        public float InterestRate { get; set; }
	    public IAccount Account { get; set; }
	    public List<IOpHistory> History { get; set; }

        public Loan(float amount, IAccount account)
        {
            Account = account;
            Amount = amount;
            History = new List<IOpHistory>();
        }

        public void Execute(Command command, object[] parameters)
        {
            throw new NotImplementedException();
        }

	    public void Execute()
	    {
            Account.Balance += Amount;
            MontlyCost += Amount;
            Amount += Amount;
            Account.History.Add(new OpHistory("New Loan " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
	    }
	}
}

