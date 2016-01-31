using System.Linq;

namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    class Transfer : IOperation
    {
        public Commands Command { get; set; }
        public float Amount { get; set; }
        public IAccount Creditor { get; set; }
        public IAccount Debitor { get; set; }
        public List<IOperationHistory> History { get; set; }

        public Transfer(float amount, IAccount debitor, IAccount creditor)
        {
            Debitor = debitor;
            Creditor = creditor;
            Amount = amount;
            History = new List<IOperationHistory>();
        }

        public void Do()
        {
            if (Debitor.Balance - Amount >= 0)
            {
                Debitor.Balance -= Amount;
                Creditor.Balance = Creditor.Balance + Amount;
                History.Add(new OperationHistory(Debitor.CustomerId+ " payed " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, true, DateTime.Now));
                Debitor.History.Add(new OperationHistory("Payed " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, true, DateTime.Now));
                Creditor.History.Add(new OperationHistory("Recieved " + Amount + " " + Creditor.Type + " from: " + Debitor.CustomerId, true, DateTime.Now));
            }
            else
            {
                History.Add(new OperationHistory("Transfer rejected! Insufficient funds!", false, DateTime.Now));
            }
        }

        public void Undo()
        {
            if (History.Last().Result) {
                Debitor.Balance += Amount;
                Creditor.Balance -= Amount;
                History.Add(new OperationHistory(Debitor.CustomerId + " Cancelled Transfer " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, true, DateTime.Now));
                Debitor.History.Add(new OperationHistory("Transfer Cancelled " + Amount + " " + Debitor.Type + " to: " + Creditor.CustomerId, true, DateTime.Now));
                Creditor.History.Add(new OperationHistory("Transfer Returned " + Amount + " " + Creditor.Type + " to: " + Debitor.CustomerId, true, DateTime.Now));
            }
            else
            {
                History.Add(new OperationHistory("Transfer cancel failed! Last operation wasn't succesful!", false, DateTime.Now));
            }
        }
    }
}
