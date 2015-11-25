namespace SDM.Interfaces
{
    public interface ILoan
    {
        float Amount { get; set; }
        float MontlyCost { get; set; }
        float InterestRate { get; set; }
        IOpHistory History { get; set; }
    }
}