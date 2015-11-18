using System;
using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IBank
    {
        Random CreateRandom { get; set; }

        float[] InterestRates { get; set; }
        List<Operation> HistoryOfOperations { get; set; }

        List<ICustomer> Customers { get; set; }
        List<IAccount> Accounts { get; set; }
    }
}
