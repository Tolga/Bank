using System;

namespace SDM.Interfaces
{
    public interface IDeposit
    {
        int DaysRemaining { get; set; }
        double InterestRate { get; set; }
        IAccount AccountToPay { get; set; }
        Boolean PayLinkedAccount();
        Boolean CloseDeposit();
    }
}