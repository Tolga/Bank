using System;
using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IAccount
    {
        int Id { get; set; }
        int CustomerId { get; set; }
        string Type { get; set; }
        float Balance { get; set; }
        float InterestRate { get; set; }
        DateTime OpeningDate { get; set; }
        List<IOpHistory> History { get; set; }

        float AllowedDebit { get; set; }
        List<IDebit> Debits { get; set; }
    }
}
