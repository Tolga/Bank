namespace SDM
{
    using System.Collections.Generic;
    using Interfaces;

    public class Customer : ICustomer
    {
        public Customer(int newId, string newName, List<IAccount> accounts = null)
        {
            Id = newId;
            Name = newName;
            Accounts = accounts ?? new List<IAccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; }
    }
}
