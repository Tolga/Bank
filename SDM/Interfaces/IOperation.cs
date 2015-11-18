using System;

namespace SDM.Interfaces
{
    public interface IOperation
	{
		/* examples of operations include: 
		 * payment, withdrawal, 
		 * interest calculation,
		 * change of the interest rate, 
		 * making deposit, 
		 * premature closing the deposit, opening a credit, credit payment, debit, reporting
		 */
		IBank Bank { get; set; }
		DateTime DateOfExecution { get; set; }
		String Description { get; set; }
	}


}

