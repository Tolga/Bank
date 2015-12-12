namespace SDM
{
    class InterestCalculationDeposit : InterestCalculation
    {
        public override float CalculateInterest(Account ac)
        {
			return ac.Balance*0.05f;
        }
    }
}
