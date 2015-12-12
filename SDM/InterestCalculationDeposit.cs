using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM
{
    class InterestCalculationDeposit : InterestCalculation
    {
        public override float calculateInterest(Account ac)
        {
			return ac.Balance*0.05f;
        }
    }
}
