namespace SDM
{
	class OperationInterestCalculationLoan : OperationInterestCalculation
	{
		public override float CalculateInterest(Account ac)
		{
			return -ac.Balance*0.05f;
		}
	}
}

