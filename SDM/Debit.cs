namespace SDM
{
    using System;
    using System.Linq;
    using Interfaces;

    class Debit : IDebit
    {
        public float Amount { get; set; }
        public IOpHistory History { get; set; }

        public Debit(float amount, IAccount account)
        {
            Amount = amount;

            if (account.AllowedDebit >= account.Debits.Sum(d => d.Amount))
            {
                account.AllowedDebit -= amount;
                account.Balance += amount;
                History = new OpHistory("New Debit " + amount + " " + account.Type + " on Account: " + account.Id, DateTime.Now);
                account.History.Add(History);
                account.Debits.Add(this);
            }
            else
            {
                History = new OpHistory("Debit rejected " + amount + " " + account.Type + " on Account: " + account.Id, DateTime.Now);
                account.History.Add(History);
            }
        }
    }
}
