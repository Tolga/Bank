using System.Collections.Generic;
using System.Linq;
using SDM.Exceptions;

namespace SDM
{
    using System;
    using Interfaces;

    class Debit : IDebit, IOperation
    {
        public Debit(float amount, IAccount account)
        {
            Amount = amount;
            Account = account;
            History = new List<IOpHistory>();
        }

        public void Execute(Command command, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            try
            {
                Account.Balance -= Amount;
                History.Add(new OpHistory("Debit operation finished successfully. " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));

            }
            catch (ExceededDebitException e)
            {
                History.Add(new OpHistory("Debit operation rejected " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
            }

        }

        public IAccount Account { get; set; }
        public float Amount { get; set; }
        public List<IOpHistory> History { get; set; }
    }
}
