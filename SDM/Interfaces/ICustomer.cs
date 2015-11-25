namespace SDM.Interfaces
{
    using System.Collections.Generic;

    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IAccount> Accounts { get; set; }
        List<ILoan> Loans { get; set; }
    }
}
