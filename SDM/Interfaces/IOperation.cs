namespace SDM.Interfaces
{
    using System.Collections.Generic;

    public interface IOperation
    {
        List<IOpHistory> History { get; set; }
        void Debit(float amount, IAccount account);
        void Pay(float amount, IAccount debitor, IAccount creditor);
    }
}