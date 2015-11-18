namespace SDM.Interfaces
{
    public interface ICustomer
    {
        IBank Bank { get; set; }

        int Id { get; set; }
        string Name { get; set; }
    }
}
