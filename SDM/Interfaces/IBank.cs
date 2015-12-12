using System;
using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IBank
    {
        Random CreateRandom { get; set; }

        float Balance { get; set; }
        float[] InterestRates { get; set; }

        List<ICustomer> Customers { get; set; }
        List<IOpHistory> History { get; set; }
    }
}
