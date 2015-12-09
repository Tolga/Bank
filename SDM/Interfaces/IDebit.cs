using System.Collections.Generic;

namespace SDM.Interfaces
{
    public interface IDebit
    {
        float Amount { get; set; }
        IAccount Account { get; set; }
        List<IOpHistory> History { get; set; }
        void Execute();
    }
}