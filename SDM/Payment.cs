namespace SDM
{
    using System;
    using Interfaces;

    class Payment : IPayment
    {
        public Payment(float amount, IAccount debitor, IAccount creditor)
        {
            if (debitor.Balance - amount >= 0)
            {
                debitor.Balance -= amount;
                creditor.Balance = creditor.Balance + amount;
                debitor.History.Add(new OpHistory("Payed " + amount + " " + debitor.Type + " to: " + creditor.CustomerId, DateTime.Now));
                creditor.History.Add(new OpHistory("Recieved " + amount + " " + creditor.Type + " from: " + debitor.CustomerId, DateTime.Now));
                History = new OpHistory(debitor.CustomerId + " payed " + amount + " " + debitor.Type + " to: " + creditor.CustomerId, DateTime.Now);
            }
            else
            {
                History = new OpHistory("Payment rejected! Insufficient funds!", DateTime.Now);
            }
        }

        public IOpHistory History { get; set; }
    }
}
