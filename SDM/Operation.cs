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

        public void Execute(Command command, object[] parameters)
	    {
	        switch (command)
	        {
                case Command.Pay:
                    new Payment((int)parameters[0], (IAccount)parameters[1], (IAccount)parameters[2]).Execute();
                break;
                case Command.Debit:
                    new Debit((int)parameters[0], (IAccount)parameters[1]).Execute();
                break;
                case Command.Loan:
                    new Loan((int)parameters[0], (IAccount)parameters[1]).Execute();
                break;
	        }
	    }

	    public List<IOpHistory> History { get; set; }

        /*

        public void Loan(float amount, IAccount account)
        {
            ILoan loan = new Loan(amount, account);
            History.Add(loan.History);
	    }
        */
	}
}

