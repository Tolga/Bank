using System.Linq;

namespace SDM
{
    using Interfaces;

    public class Customer : ICustomer
    {
        public Customer(IBank bank, string newName, int newId = 0) {
            Bank = bank;
            Id = (newId == 0) ? NewCustomerId() : newId;
            Name = newName;
        }

        /*
         * Create a new id, check if is there any other customer with same id. If there is then try another one.
         */
        private int NewCustomerId()
        {
            var id = Bank.CreateRandom.Next(99999999, 999999999);

            if (Bank.Customers != null)
                return (Bank.Customers.FirstOrDefault(cid => cid.Id == id) != null) ? NewCustomerId() : id;

            return id;
        }

        public IBank Bank { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
