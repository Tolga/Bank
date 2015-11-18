using System;
using System.Collections.Generic;
using System.Linq;

namespace SDM
{
    using Interfaces;

    public class Account : IAccount
    {
        public Account(IBank bank, int newCustomerId, int newId = 0, string newType = "PLN", float newBalance = 0.00F, float newInterestRate = 0.05F, DateTime newOpeningDate = default(DateTime), List<Operation> newOpHistory = null)
        {
            Bank = bank;
            Id = (newId == 0) ? NewAccountId() : newId;
            CustomerId = newCustomerId;
			Type = newType;
			Balance = newBalance;
            InterestRate = newInterestRate;
            OpeningDate = (newOpeningDate == default(DateTime)) ? DateTime.Now : newOpeningDate;
            OperationHistory = newOpHistory ?? new List<Operation>();
		}

        /*
         * Create a new id, check if is there any other customer with same. If there is then try again.
         */
        private int NewAccountId()
        {
            var id = Bank.CreateRandom.Next(99999999, 999999999);

            if (Bank.Accounts != null)
                return (Bank.Accounts.FirstOrDefault(aid => aid.Id == id) != null) ? NewAccountId() : id;

            return id;
        }

        #region account

        public IBank Bank { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
        public float InterestRate { get; set; }
        public DateTime OpeningDate { get; set; }
        public List<Operation> OperationHistory { get; set; }
        #endregion
    }
}
