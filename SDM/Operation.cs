using System.Linq;

namespace SDM
{
    using System.Collections.Generic;
	using Interfaces;

	public class Operation : IOperation
    {
        private object[] Parameters { get; }
        private Commands Command { get; }
        public List<IOpHistory> History { get; set; }
        private IOperation Result { get; set; }

        public Operation(Commands command, object[] parameters)
	    {
            Command = command;
            Parameters = parameters;
            History = new List<IOpHistory>();

            switch (Command)
            {
                case Commands.Pay:
                    Result = new Payment((int)Parameters[0], (IAccount)Parameters[1], (IAccount)Parameters[2]);
                    break;
                case Commands.Debit:
                    Result = new Debit((int)Parameters[0], (IAccount)Parameters[1]);
                    break;
                case Commands.Loan:
                    Result = new Loan((int)Parameters[0], (IAccount)Parameters[1]);
                    break;
            }
	    }

        public void Do()
        {
            Result.Do();
            History.Add(Result.History.Last());
        }

        public void Undo()
        {
            Result.Undo();
            History.Add(Result.History.Last());
        }
    }
}

