namespace SDM
{
    using System.Collections.Generic;
	using Interfaces;

	public class Operation : IOperation
	{
        public Operation()
	    {
            History = new List<IOpHistory>();
	    }

	    public void Pay(float amount, IAccount debitor, IAccount creditor)
	    {
            IPayment payment = new Payment(amount, debitor, creditor);
            History.Add(payment.History);
	    }

        public void Loan(float amount, IAccount account)
        {
            ILoan loan = new Loan(amount, account);
            History.Add(loan.History);
	    }

        public void Debit(float amount, IAccount account)
        {
            IDebit debit = new Debit(amount, account);
            History.Add(debit.History);
	    }

        public List<IOpHistory> History { get; set; }
	}
}

