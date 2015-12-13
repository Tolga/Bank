namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Exceptions;

    class Debit : ICommand
    {
        public Commands Command { get; set; }
        public IAccount Account { get; set; }
        public float Amount { get; set; }

        public List<IOpHistory> History { get; set; }

        public Debit(float amount, IAccount account)
        {
            Amount = amount;
            Account = account;
            History = new List<IOpHistory>();
        }

        public void Do()
        {
            try
            {
                Account.Balance -= Amount;
                History.Add(new OpHistory("Debit operation finished successfully. " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
            }
            catch (ExceededDebitException)
            {
                History.Add(new OpHistory("Debit operation rejected " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
            }
        }
        public void Undo()
        {
            Account.Balance += Amount;
            History.Add(new OpHistory("Debit operation cancelled successfully. " + Amount + " " + Account.Type + " on Account: " + Account.Id, DateTime.Now));
        }
    }
}
