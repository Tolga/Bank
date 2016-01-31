using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IBank
    {
        int BankId { get; set; }
        IBankNetwork BankNetwork { get; set; }
        void Receive(int from, Commands command, int amount);
        void Send(int to, Commands command, int amount);

        float Balance { get; set; }
        List<ICustomer> Customers { get; set; }
        List<IOperationHistory> History { get; set; }
    }
}
