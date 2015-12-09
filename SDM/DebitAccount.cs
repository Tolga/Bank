using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using SDM.Exceptions;
using SDM.Interfaces;

namespace SDM
{
    internal class DebitAccount : IAccount
    {
        private readonly IAccount _account;

        public float AllowedDebit { get; set; }

        public float Debit { get; set; }

        public float Balance
        {
            get { return _account.Balance - Debit; }
            
            set
            {
                Contract.Requires<ExceededDebitException>(value >= -AllowedDebit);

                if (value < 0)
                {     
                    Debit = -value;
                    _account.Balance = 0;
                }
                else
                {
                    _account.Balance = value;
                    Debit = 0;
                }
            }
        }

        #region inherited properties
        public int Id
        {
            get { return _account.Id; }
            set { _account.Id = value; }
        }

        public int CustomerId
        {
            get { return _account.CustomerId; }
            set { _account.CustomerId = value; }
        }

        public string Type
        {
            get { return _account.Type; }
            set { _account.Type = value; }
        }

        public float InterestRate
        {
            get { return _account.InterestRate; }
            set { _account.InterestRate = value; }
        }

        public DateTime OpeningDate
        {
            get { return _account.OpeningDate; }
            set { _account.OpeningDate = value; }
        }

        public List<IOpHistory> History
        {
            get { return _account.History; }
            set { _account.History = value; }
        }
        #endregion

        public DebitAccount(IAccount account, float allowedDebit = 250.00F, float debit = 0F)
        {
            this._account = account;
            this.AllowedDebit = allowedDebit;
            this.Debit = debit;

            account.Balance = account.Balance - 100;
            account.Balance = account.Balance + 100;
        }

    }
}
