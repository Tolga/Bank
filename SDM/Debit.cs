using System.Linq;

namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Debit : IOperation
    {
        public IAccount Account { get; set; }
        public float Amount { get; set; }
        public List<IOperationHistory> History { get; set; }

        public Debit(float amount, IAccount account)
        {
            Amount = amount;
            Account = account;
            History = new List<IOperationHistory>();
        }

        public void Do()
        {
            if (Account.AllowedDebit >= Amount)
            {
                Account.AllowedDebit -= Amount;
                Account.Balance += Amount;
                Account.Debits += Amount;
                History.Add(new OperationHistory("Debit operation finished successfully. " + Amount + " on Account: " + Account.AccountId, true, DateTime.Now));
            }
            else
            {
                History.Add(new OperationHistory("Debit operation rejected " + Amount + " on Account: " + Account.AccountId, false, DateTime.Now));
            }
        }
        public void Undo()
        {
            if (History.Last().Result)
            {
                Account.AllowedDebit += Amount;
                Account.Balance -= Amount;
                Account.Debits -= Amount;
                History.Add(new OperationHistory("Debit operation cancelled successfully. " + Amount + " on Account: " + Account.AccountId, true, DateTime.Now));
            }
            else
            {
                History.Add(new OperationHistory("Debit operation cancel failed! Last Debit operation wasn't successful!" + Amount + " on Account: " + Account.AccountId, false, DateTime.Now));
            }
        }
    }
}
