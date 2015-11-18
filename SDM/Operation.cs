using System;
using System.Globalization;

namespace SDM
{
	using Interfaces;

	public class Operation : IOperation
	{
		public Operation(IBank bank)
		{	
			Bank = bank;
			DateOfExecution = DateOfExecution;
			Description = Description;
			Setup(bank);
		}

	    void Setup(IBank bnk){
            Bank = bnk;
			DateOfExecution = DateTime.Now;
			Description = DateOfExecution.ToString(CultureInfo.InvariantCulture) + " : " + GetType();
		}

		public IBank Bank { get; set; }
		public DateTime DateOfExecution{ get; set;}
		public String Description{ get; set; }

	}
}

