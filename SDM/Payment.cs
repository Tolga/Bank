using System.Collections.Generic;

namespace SDM
{
    using System;
    using Interfaces;

    class Payment : IPayment, IOperation
    {
        public Payment(float amount, IAccount debitor, IAccount creditor)
        {
            Debitor = debitor;
            Creditor = creditor;
            Amount = amount;
            History = new List<IOpHistory>();
        }

        public void Execute(Command command, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            if (Debitor.Balance - Amount >= 0)
            {
                Debitor.Balance -= Amount;
                Creditor.Balance = Creditor.Balance + Amount;
                Debitor.History.Add(new OpHistory("Payed " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, DateTime.Now));
                Creditor.History.Add(new OpHistory("Recieved " + Amount + " " + Creditor.Type + " from: " + Debitor.CustomerId, DateTime.Now));
                History.Add(new OpHistory(Debitor.CustomerId + " payed " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, DateTime.Now));
            }
            else
            {
                History.Add(new OpHistory("Payment rejected! Insufficient funds!", DateTime.Now));
            }
        }


        public float Amount { get; set; }
        public IAccount Creditor { get; set; }
        public IAccount Debitor { get; set; }
        public List<IOpHistory> History { get; set; }
    }
}
