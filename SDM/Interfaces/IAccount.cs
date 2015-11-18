using System;
using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IAccount
    {
        IBank Bank { get; set; }

        int Id { get; set; }
        int CustomerId { get; set; }
        string Type { get; set; }
        float Balance { get; set; }
        float InterestRate { get; set; }
        DateTime OpeningDate { get; set; }
        List<Operation> OperationHistory { get; set; }
    }
}
