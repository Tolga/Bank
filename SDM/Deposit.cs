namespace SDM
{
    using System;
	using Interfaces;

	public class Deposit : IDeposit
	{
		public int DaysRemaining { get; set; }
		public double InterestRate { get; set; }
		public IAccount AccountToPay { get; set; }

		public Deposit (int daysRemaining, double interestRate, IAccount account)
		{
			DaysRemaining = daysRemaining;
			InterestRate = interestRate;
			AccountToPay = account;
		}

		public Boolean PayLinkedAccount() {
			return false;
		}

		public Boolean CloseDeposit() {
			return false;
		}
	}
}
