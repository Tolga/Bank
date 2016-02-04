using System.Linq;

namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Transfer : IOperation
    {
        public Operations Operation { get; set; }
        public float Amount { get; set; }
        public IAccount To { get; set; }
        public IAccount From { get; set; }
        public List<IOperationHistory> History { get; set; }

        public Transfer(float amount, IAccount from, IAccount to)
        {
            From = from;
            To = to;
            Amount = amount;
            History = new List<IOperationHistory>();
        }

        public void Do()
        {
            if (From.Balance - Amount >= 0)
            {
                From.Balance -= Amount;
                To.Balance = To.Balance + Amount;
                History.Add(new OperationHistory(From.CustomerId+ " payed " + Amount + " " + From.Type + " to: " + To.CustomerId, true, DateTime.Now));
                From.History.Add(new OperationHistory("Payed " + Amount + " " + From.Type + " to: " + To.CustomerId, true, DateTime.Now));
                To.History.Add(new OperationHistory("Recieved " + Amount + " " + To.Type + " from: " + From.CustomerId, true, DateTime.Now));
            }
            else
            {
                History.Add(new OperationHistory("Transfer rejected! Insufficient funds!", false, DateTime.Now));
            }
        }

        public void Undo()
        {
            if (History.Last().Result) {
                From.Balance += Amount;
                To.Balance -= Amount;
                History.Add(new OperationHistory(From.CustomerId + " Cancelled Transfer " + Amount + " " + From.Type + " to: " + To.CustomerId, true, DateTime.Now));
                From.History.Add(new OperationHistory("Transfer Cancelled " + Amount + " " + From.Type + " to: " + To.CustomerId, true, DateTime.Now));
                To.History.Add(new OperationHistory("Transfer Returned " + Amount + " " + To.Type + " to: " + From.CustomerId, true, DateTime.Now));
            }
            else
            {
                History.Add(new OperationHistory("Transfer cancel failed! Last operation wasn't succesful!", false, DateTime.Now));
            }
        }
    }
}
