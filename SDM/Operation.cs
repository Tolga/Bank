using System;
using System.Linq;

namespace SDM
{
    using System.Collections.Generic;
	using Interfaces;

	public class Operation : IOperation
    {
        private object[] Parameters { get; }
        private Operations Command { get; }
        public List<IOperationHistory> History { get; set; }
        private IOperation Result { get; set; }

        public Operation(Operations command, object[] parameters)
	    {
            Command = command;
            Parameters = parameters;
            History = new List<IOperationHistory>();

            switch (Command)
            {
                case Operations.Transfer:
                    Result = new Transfer(Convert.ToSingle(Parameters[0]), (IAccount)Parameters[1], (IAccount)Parameters[2]);
                    break;
                case Operations.Debit:
                    Result = new Debit(Convert.ToSingle(Parameters[0]), (IAccount)Parameters[1]);
                    break;
                case Operations.Deposit:
                    Result = new Deposit((ICustomer)Parameters[0], Convert.ToSingle(Parameters[1]), (DateTime)Parameters[2]);
                    break;
                case Operations.Loan:
                    Result = new Loan(Convert.ToSingle(Parameters[0]), (IAccount)Parameters[1]);
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

