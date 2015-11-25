namespace SDM.Interfaces
{
    public interface IPayment
    {
        IOpHistory History { get; set; }
    }
}