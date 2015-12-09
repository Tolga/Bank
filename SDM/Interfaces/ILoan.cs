using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface ILoan
    {
        float Amount { get; set; }
        float MontlyCost { get; set; }
        float InterestRate { get; set; }
        List<IOpHistory> History { get; set; }
        void Execute();
    }
}