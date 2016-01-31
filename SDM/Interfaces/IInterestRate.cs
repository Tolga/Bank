namespace SDM.Interfaces
{
    public interface IInterestRate
    {
        IAccount Account { get; set; }
        void Calculate();
        float Check();
    }
}