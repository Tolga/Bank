using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM
{
	class InterestCalculationLoan : InterestCalculation
	{
		public override float calculateInterest(Account ac)
		{
			return -ac.Balance*0.05f;
		}
	}
}

