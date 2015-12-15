namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Deposit : IDeposit
	{
		public int DaysRemaining { get; set; }
		public IAccount AccountToPay { get; set; }

        #region deposit_attributes

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
        public float InterestRate { get; set; }
        public DateTime OpeningDate { get; set; }
        public List<IOpHistory> History { get; set; }
        public IBank Bank { get; set; }

        public float calculateInterests(IOperation op)
        {
            IOperation op = new 
            History.Add (op);
            Bank.Add( Op ) ;

            return 0;
        }

        #endregion

        public Deposit (int daysRemaining, float interestRate, IAccount account)
		{
			DaysRemaining = daysRemaining;
			InterestRate = interestRate;
			AccountToPay = account;
		}

		public Boolean PayLinkedAccount() {
			return false;
		}

        public Boolean CloseDeposit()
        {

            IOperation op = new OperationInterestCalculationDeposit(this);


            //History.Add(op);
            //Bank.Add(Op);

            return 0;

            return false;
        }

        internal static void Do()
        {
            throw new NotImplementedException();
        }
    }
}
