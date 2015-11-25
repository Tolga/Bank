namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Account : IAccount
    {
        public Account(int newId, int newCustomerId, float newBalance = 100.00F, string newType = "PLN", float newInterestRate = 0.05F, DateTime newOpeningDate = default(DateTime), List<IOpHistory> newOpHistory = null, float allowedDebit = 250.00F, List<IDebit> currentDebits = null)
        {
            Id = newId;
            CustomerId = newCustomerId;
			Type = newType;
			Balance = newBalance;
            InterestRate = newInterestRate;
            OpeningDate = (newOpeningDate == default(DateTime)) ? DateTime.Now : newOpeningDate;
            History = newOpHistory ?? new List<IOpHistory>();
            AllowedDebit = allowedDebit;
            Debits = currentDebits ?? new List<IDebit>();
		}

        #region account
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
        public float InterestRate { get; set; }
        public DateTime OpeningDate { get; set; }
        public List<IOpHistory> History { get; set; }
        public float AllowedDebit { get; set; }
        public List<IDebit> Debits { get; set; }
        #endregion
    }
}
