using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IBank
    {
        int BankId { get; set; }

        string Name { get; set; }

        IBankNetwork BankNetwork { get; set; }

        void Receive(ICustomer from, ICustomer to, float amount);
        void Send(ICustomer from, ICustomer to, float amount);

        float Balance { get; set; }

        List<ICustomer> Customers { get; set; }
        List<IOperationHistory> History { get; set; }

        int NewCustomerId();
        void CreateAccounts();
    }
}
