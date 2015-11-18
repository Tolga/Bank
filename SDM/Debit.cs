using System;

namespace SDM
{

	/* DO NOT COMPILE for some errors .. */
	using Interfaces;
	public class Debit : IDebit
	{
		public Debit (float allowed_debit, float current_debit)
		{
			this.allowed_debit = allowed_debit;
			this.current_possible_debit = 0;
		}

		public Boolean Pay(int amount, IAccount receiver){
			if (this.Balance - amount + this.current_possible_debit >= 0) {		
				this.Balance -= amount;
				if(this.Balance < 0){
					this.current_possible_debit += this.Balance;
					this.Balance = 0;
				}
				receiver.Balance = receiver.Balance + amount;
				return true;
			}
			return false;
		}

//		public Boolean ReceivePayment(int amount){
//			if(amount > 0){
//				if(this.current_possible_debit < this.allowed_debit){
//					
//				receiver.Balance += amount;
//				return true;
//			}
//			return false;
//		}

		public float allowed_debit { get; set; }
		public float current_possible_debit { get; set; }

		public int Id { get; set; }
		public string Name { get; set; }
		public float Balance { get; set; }
		public float InterestRate { get; set; }
		public DateTime OpeningDate { get; set; }

	}
}

