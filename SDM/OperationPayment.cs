using System;

namespace SDM
{
	using Interfaces;

	public class OperationPayment
	{
		public OperationPayment(IBank bank, float amount, IAccount debitor, IAccount creditor)
		{
			this.Amount = amount;
			this.Debitor = debitor;
			this.Creditor = creditor;

			this.Description += " - " + debitor.Type + " pay " + amount + " euro to :" + creditor.Type;
		}

		public Boolean DoOperation(){
			return Pay(this.Amount, this.Debitor, this.Creditor);
		}

		/*
         * Permit the acount to make a payment
         */
        public Boolean Pay(float amount, IAccount debitor, IAccount creditor)
        {
			if (this.Debitor.Balance - amount >= 0) {
				this.Debitor.Balance -= amount;
				creditor.Balance = creditor.Balance + amount;
				return true;
			}
			return false;
		}

		public float Amount;
		public IAccount Debitor;
		public IAccount Creditor;

		IBank Bank { get; set; }
		DateTime DateOfExecution { get; set; }
		String Description{ get; set; }
	}
}

