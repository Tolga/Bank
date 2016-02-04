namespace SDM
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Account : IAccount
    {
        public Account(ICustomer customer, AccountType type = AccountType.Normal, float balance = 0.0F, DateTime closeDate = default(DateTime), IInterestRate state = null, float allowedDebit = 250.00F)
        {
            AccountId = customer.NewAccountId();
            CustomerId = customer.CustomerId;
            Balance = balance;
            OpenDate = DateTime.Now;
            CloseDate = closeDate;
            History = new List<IOperationHistory>();
            AllowedDebit = allowedDebit;
            Debits = 0.0F;
            Type = type;
            State = state ?? new Normal(this);
            State.Check();
        }

        #region account
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public float Balance {
            get { return _balance;  }
            set {
                _balance = value;
                State?.Check();
            }
        }
        private float _balance;
        public IInterestRate State { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public List<IOperationHistory> History { get; set; }
        public float AllowedDebit { get; set; }
        public float Debits { get; set; }
        public AccountType Type { get; set; }
        #endregion
    }
}