namespace SDM
{
    using System.Collections.Generic;
	using Interfaces;

	public class Operation : IOperation
    {
        public List<IOpHistory> History { get; set; }

        public Operation()
	    {
            History = new List<IOpHistory>();
	    }

        public ICommand Commit(Commands command, object[] parameters)
	    {
            ICommand result = null;
            switch (command)
	        {
                case Commands.Pay:
                    result = new Payment((int)parameters[0], (IAccount)parameters[1], (IAccount)parameters[2]);
                    break;
                case Commands.Debit:
                    result = new Debit((int)parameters[0], (IAccount)parameters[1]);
                    break;
                case Commands.Loan:
                    result = new Loan((int)parameters[0], (IAccount)parameters[1]);
                    break;
	        }

            return result;
	    }

        /*

        public void Loan(float amount, IAccount account)
        {
            ILoan loan = new Loan(amount, account);
            History.Add(loan.History);
	    }
        */
	}
}

