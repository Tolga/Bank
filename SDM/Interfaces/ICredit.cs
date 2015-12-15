using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface ICredit : IAccount
    {
        int DaysRemaining { get; set; }
        IAccount AccountToPay { get; set; }
        Boolean PayLinkedAccount();

        //closeLoan() ?
        float calculateInterests();
    }
}