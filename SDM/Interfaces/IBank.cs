using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IBank
    {
        float Balance { get; set; }
        float[] InterestRates { get; set; }

        List<ICustomer> Customers { get; set; }
        List<IOperationHistory> History { get; set; }
    }
}
