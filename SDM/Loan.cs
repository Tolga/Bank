namespace SDM
{
    using System;
	using Interfaces;

	public class Loan : ILoan
	{
        public float Amount { get; set; }
        public float MontlyCost { get; set; }
        public float InterestRate { get; set; }
        public IOpHistory History { get; set; }

        public Loan(float amount, IAccount account)
        {
            account.Balance += amount;
            MontlyCost += amount;
            Amount += amount;

            History = new OpHistory("New Loan " + amount + " " + account.Type + " on Account: " + account.Id, DateTime.Now);
            account.History.Add(History);
        }
	}
}

