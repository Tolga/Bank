using System;
using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IAccount
    {
        int AccountId { get; set; }
        int CustomerId { get; set; }
        float Balance { get; set; }
        DateTime OpenDate { get; set; }
        DateTime CloseDate { get; set; }
        IInterestRate State { get; set; }
        List<IOperationHistory> History { get; set; }
        float AllowedDebit { get; set; }
        float Debits { get; set; }
        AccountType Type { get; set; }
    }

    public enum AccountType
    {
        Normal,
        Deposit,
        Loan
    }
}
