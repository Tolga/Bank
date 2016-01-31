namespace SDM.Interfaces
{
    public interface IBankNetwork
    {
        void Register(IBank bank);
        void Send(int from, int to, Commands command, int amount);
    }
}