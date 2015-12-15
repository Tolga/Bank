namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    class Payment : IOperation
    {
        public Commands Command { get; set; }
        public float Amount { get; set; }
        public IAccount Creditor { get; set; }
        public IAccount Debitor { get; set; }
        public List<IOpHistory> History { get; set; }

        public Payment(float amount, IAccount debitor, IAccount creditor)
        {
            Debitor = debitor;
            Creditor = creditor;
            Amount = amount;
            History = new List<IOpHistory>();
        }

        public void Do()
        {
            if (Debitor.Balance - Amount >= 0)
            {
                Debitor.Balance -= Amount;
                Creditor.Balance = Creditor.Balance + Amount;
                History.Add(new OpHistory(Debitor.CustomerId + " payed " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, DateTime.Now));
                Debitor.History.Add(new OpHistory("Payed " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, DateTime.Now));
                Creditor.History.Add(new OpHistory("Recieved " + Amount + " " + Creditor.Type + " from: " + Debitor.CustomerId, DateTime.Now));
            }
            else
            {
                History.Add(new OpHistory("Payment rejected! Insufficient funds!", DateTime.Now));
            }
        }

        public void Undo()
        {
            Debitor.Balance += Amount;
            Creditor.Balance -= Amount;
            History.Add(new OpHistory(Debitor.CustomerId + " Cancelled Payment " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, DateTime.Now));
            Debitor.History.Add(new OpHistory("Payment Cancelled " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, DateTime.Now));
            Creditor.History.Add(new OpHistory("Payment Returned " + Amount + " " + Creditor.Type + " to: " + Debitor.CustomerId, DateTime.Now));
        }
    }
}
