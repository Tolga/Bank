using System.Linq;

namespace SDM
{
    using Interfaces;
    using System.Collections.Generic;

    public class BankNetwork : IBankNetwork
    {
        public Dictionary<int, IBank> Banks { get; set; }

        public BankNetwork()
        {
            Banks = new Dictionary<int, IBank>();
        }

        public void Register(IBank bank)
        {
            if (!Banks.ContainsValue(bank))
            {
                Banks[bank.BankId] = bank;
            }

            bank.BankNetwork = this;
        }

        public void Send(ICustomer from, ICustomer to, float amount)
        {
            IBank reciverBank = Banks.Values.Single(b => b.Customers.Contains(to));

            IBank bank = Banks[reciverBank.BankId];

            if (bank != null)
            {
                bank.Receive(from, to, amount);
            }
        }
    }
}