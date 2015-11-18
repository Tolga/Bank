using System;

namespace SDM
{
	using Interfaces;

	public class Deposit 
	{
		int days_remaining{ get; set; }
		double interest_rate{ get; set; }
		IAccount account_to_pay{ get; set; }

		public Deposit (int days_remaining,  double interest_rate, IAccount account )
		{
			this.days_remaining = days_remaining;
			this.interest_rate = interest_rate;
			this.account_to_pay = account;
		}

		public Boolean payLinkedAccount(){
			return false;
		}

		public Boolean closeDeposit(){
			return false;
		}
	}
}
