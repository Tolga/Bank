namespace SDM.Interfaces
{
    public interface IPayment
    {
        float Amount { get; set; }
        IAccount Creditor { get; set; }
        IAccount Debitor { get; set; }
        void Execute();
    }
}