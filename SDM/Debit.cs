using System.Collections.Generic;
using System.Linq;

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
            if (Account.AllowedDebit >= Account.Debits.Sum(d => d.Amount))
            {
                Account.AllowedDebit -= Amount;
                Account.Balance += Amount;
                History.Add(new OpHistory("New Debit " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
                Account.Debits.Add(this);
            }
            else
            {
                History.Add(new OpHistory("Debit rejected " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
            }
        }

        public IAccount Account { get; set; }
        public float Amount { get; set; }
        public List<IOpHistory> History { get; set; }
    }
}
