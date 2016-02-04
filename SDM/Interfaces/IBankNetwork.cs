using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IBankNetwork
    {
        Dictionary<int, IBank> Banks { get; set; }
        void Register(IBank bank);
        void Send(ICustomer from, ICustomer to, float amount);
    }
}