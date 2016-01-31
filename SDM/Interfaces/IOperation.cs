namespace SDM.Interfaces
{
    using System.Collections.Generic;

    public interface IOperation
    {
        void Do();
        void Undo();
        List<IOperationHistory> History { get; set; }
    }
    public enum Commands
    {
        Transfer,
        Debit,
        Deposit,
        Loan
    }
}