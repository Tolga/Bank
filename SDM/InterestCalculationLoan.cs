namespace SDM
{
	class InterestCalculationLoan : InterestCalculation
	{
		public override float CalculateInterest(Account ac)
		{
			return -ac.Balance*0.05f;
		}
	}
}

