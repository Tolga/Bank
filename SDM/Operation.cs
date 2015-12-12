namespace SDM
{
    using System.Collections.Generic;
	using Interfaces;

    /// <summary>
    /// Invoker
    /// </summary>
	public class Operation : IOperation
    {
        private object[] Parameters { get; }
        private Commands Command { get; }
        public List<IOpHistory> History { get; set; }

        public Operation(Commands command, object[] parameters)
	    {
            Command = command;
            Parameters = parameters;
            History = new List<IOpHistory>();
	    }

        public ICommand Commit()
	    {
            ICommand result = null;
            switch (Command)
	        {
                case Commands.Pay:
                    result = new Payment((int)Parameters[0], (IAccount)Parameters[1], (IAccount)Parameters[2]);
                    break;
                case Commands.Debit:
                    result = new Debit((int)Parameters[0], (IAccount)Parameters[1]);
                    break;
                case Commands.Loan:
                    result = new Loan((int)Parameters[0], (IAccount)Parameters[1]);
                    break;
	        }
            return result;
	    }
    }
}

