using System.Collections.Generic;

namespace SDM
{
    using Interfaces;
    
    class BankNetwork : IBankNetwork
    {
        private readonly Dictionary<int, IBank> _banks = new Dictionary<int, IBank>();

        public void Register(IBank bank)
        {
            if (!_banks.ContainsValue(bank))
            {
                _banks[bank.BankId] = bank;
            }

            bank.BankNetwork = this;
        }

        public void Send(int from, int to, Commands command)
        {
            IBank bank = _banks[to];

            if (bank != null)
            {
                bank.Receive(from, command);
            }
        }
    }
}