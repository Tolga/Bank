namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Account : IAccount
    {
        public Account(int newId, int newCustomerId, Bank bank, float newBalance = 100.00F, string newType = "PLN", float newInterestRate = 0.05F, DateTime newOpeningDate = default(DateTime), List<IOpHistory> newOpHistory = null)
        {
            Id = newId;
            CustomerId = newCustomerId;
            Type = newType;
            Balance = newBalance;
            InterestRate = newInterestRate;
            OpeningDate = (newOpeningDate == default(DateTime)) ? DateTime.Now : newOpeningDate;
            History = newOpHistory ?? new List<IOpHistory>();
            Bank = bank;

        }

        #region account
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
        public float InterestRate { get; set; }
        public DateTime OpeningDate { get; set; }
        public List<IOpHistory> History { get; set; }
        public IBank Bank { get; set; }

        public float calculateInterests(IOperation op)
        {
            //History.Add (op);
            //Bank.Add( Op ) ;

            return 0;
        }

        #endregion
    }
}