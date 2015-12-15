using System;

namespace SDM.Interfaces
{
    public interface IDeposit : IAccount,ICommand
    {
        int DaysRemaining { get; set; }
        IAccount AccountToPay { get; set; }
        Boolean PayLinkedAccount();
        Boolean CloseDeposit();
        float calculateInterests();
    }
}